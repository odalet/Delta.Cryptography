using System;
using System.ComponentModel;
using System.Linq;
using Delta.CapiNet.Asn1;
using Delta.CapiNet.Asn1.CardVerifiable;
using Delta.CertXplorer.CertManager;
using Delta.CertXplorer.Diagnostics;
using Delta.CertXplorer.Services;
using Delta.CertXplorer.UI;
using Delta.Icao.Asn1;

namespace Delta.CertXplorer.Asn1Decoder
{
    /// <summary>
    /// Main control for the ASN1 Documents
    /// </summary>
    internal partial class Asn1Viewer : ServicedUserControl, ISelectionSource
    {
        private byte[] content = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Asn1Viewer"/> class.
        /// </summary>
        public Asn1Viewer()
        {
            InitializeComponent();

            // Defaults
            ParseOctetStrings = false;
            ParseMode = Asn1ParseMode.Standard;
            ShowInvalidTaggedObjects = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether octet strings should be parsed.
        /// </summary>
        /// <value><c>true</c> if we should parse octet strings; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ParseOctetStrings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether invalid tagged objects should be shown.
        /// </summary>
        /// <value><c>true</c> if we should show invalid tagged objects; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowInvalidTaggedObjects { get; set; }

        /// <summary>
        /// Gets or sets a value indicating what specific ASN.1 parser to use.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Asn1ParseMode ParseMode { get; set; }

        #region ISelectionSource Members

        /// <summary>
        /// Occurs when the currently selected object has changed.
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Gets the currently selected object.
        /// </summary>
        /// <value>The selected object.</value>
        public object SelectedObject
        {
            get
            {
                var node = asnTreeView.SelectedNode;
                if (node != null) return node.Tag;

                return null;
            }
        }

        #endregion

        /// <summary>
        /// Initializes the control with the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Initialize(byte[] data)
        {
            try
            {
                content = data;
                hexViewer.Load(content);
            }
            catch (Exception ex)
            {
                HandleException("Unable to retrieve content: {0}.", ex);
                return;
            }

            ParseData();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GlobalSelectionService
                .GetOrCreateSelectionService(Services)
                .AddSource(this);

            // wire events
            asnTreeView.SelectedNodeChanged += (s, ev) =>
            {
                if (SelectedObject != null && SelectionChanged != null)
                    SelectionChanged(this, EventArgs.Empty);

                try
                {
                    ShowSelection();
                }
                catch (Exception ex)
                {
                    HandleException("Unable to show node: {0}.", ex);
                }
            };
        }

        public void ParseData()
        {
            try
            {
                asnTreeView.Nodes.Clear();
                hexViewer.Select(0, 0);
                asciiTextBox.Clear();
                bytesTextBox.Clear();

                switch (ParseMode)
                {
                    case Asn1ParseMode.Icao:
                        var icao = new Asn1IcaoDocument(content, ParseOctetStrings, ShowInvalidTaggedObjects);
                        _ = asnTreeView.CreateDocumentNodes(icao, "ICAO Document");
                        break;

                    case Asn1ParseMode.CardVerifiable:
                        var cv = new CVDocument(content, ParseOctetStrings, ShowInvalidTaggedObjects);
                        _ = asnTreeView.CreateDocumentNodes(cv, "Card Verifiable");
                        break;
                    default:
                        var doc = new Asn1Document(content, ParseOctetStrings, ShowInvalidTaggedObjects);
                        _ = asnTreeView.CreateDocumentNodes(doc, "Document");
                        break;
                }

                asnTreeView.ExpandAll();
            }
            catch (Exception ex)
            {
                HandleException("Unable to decode content: {0}.", ex);
            }
        }

        #region Implementation

        private void ShowData(byte[] bytes)
        {
            bytesTextBox.Text = string.Join(" ", bytes.Select(b => b.ToString("X2")).ToArray());
            asciiTextBox.Text = System.Text.Encoding.ASCII.GetString(bytes);
        }

        private void ShowSelection()
        {
            static string formatBytes(byte[] data, int maxCount)
            {
                if (data == null) return "Null";
                if (data.Length == 0) return "Empty";
                var count = Math.Min(data.Length, maxCount);
                return string.Join(" ", data.Take(count).Select(b => b.ToString("X2")).ToArray());
            }

            if (asnTreeView.SelectedNode == null || asnTreeView.SelectedNode.Tag == null)
                return;

            var tag = asnTreeView.SelectedNode.Tag;

            byte[] data = null;
            var index = 0;

            if (tag is Asn1Document asn1Document)
                data = asn1Document.Data;
            else if (tag is Asn1Object asn1Object)
            {
                data = asn1Object.Workload;
                index = asn1Object.WorkloadOffset;
                This.Logger.Debug($"Node {asn1Object}: index={index}, length={data.Length}, data={formatBytes(data, 5)}");
            }

            if (data == null) data = new byte[0]; // Safety net

            ShowData(data);
            hexViewer.Select(index, data.Length);
            if (data.Length == 0) This.Logger.Verbose("Empty node.");

            if (!hexViewer.Focused) _ = hexViewer.Focus();
            hexViewer.Refresh();
        }

        #endregion

        private void HandleException(string format, Exception ex)
        {
            var message = string.Format(format, ex.Message);
            This.Logger.Error(message);
            _ = ExceptionBox.Show(this, ex, message);
        }
    }
}
