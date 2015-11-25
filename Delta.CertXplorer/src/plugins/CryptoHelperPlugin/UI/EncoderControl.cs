﻿using System;
using System.Windows.Forms;

namespace CryptoHelperPlugin.UI
{
    public partial class EncoderControl : UserControl
    {
        public EncoderControl()
        {
            InitializeComponent();

            inbox.Text = "TG9yZW0gaXBzdW0gZG9sb3Igc2l0IGFtZXQsIGNvbnNlY3RldHVyIGFkaXBpc2NpbmcgZWxpdC4gSW50ZWdlciBuaXNpIGRvbG9yLCBwb3J0YSBhdCBudWxsYSB2aXRhZSwgZmVybWVudHVtIHRpbmNpZHVudCBlbGl0LiBTZWQgbW9sZXN0aWUgcHJldGl1bSByaXN1cyBlZ2V0IGZhdWNpYnVzLiBWZXN0aWJ1bHVtIGFudGUgaXBzdW0gcHJpbWlzIGluIGZhdWNpYnVzIG9yY2kgbHVjdHVzIGV0IHVsdHJpY2VzIHBvc3VlcmUgY3ViaWxpYSBDdXJhZTsgRHVpcyBzaXQgYW1ldCBtYXVyaXMgZXUgZHVpIHVsdHJpY2llcyB1bHRyaWNpZXMgdml0YWUgaW4gbGliZXJvLiBWaXZhbXVzIHV0IHByZXRpdW0gcHVydXMuIE1vcmJpIGVnZXQgYWxpcXVhbSBlc3QuIFBlbGxlbnRlc3F1ZSBpZCBhbGlxdWFtIGZlbGlzLgoKTnVuYyBwb3N1ZXJlIHF1aXMgdG9ydG9yIGV1IHByZXRpdW0uIFNlZCBtYWxlc3VhZGEgaXBzdW0gdXQgbnVuYyBwb3N1ZXJlIHZvbHV0cGF0LiBTdXNwZW5kaXNzZSBwcmV0aXVtIHZhcml1cyBxdWFtLCBzZWQgdGluY2lkdW50IG51bmMgdm9sdXRwYXQgaW4uIERvbmVjIHVsdHJpY2llcyBpYWN1bGlzIG1ldHVzLCBxdWlzIGJpYmVuZHVtIGVzdCB2YXJpdXMgdml0YWUuIEludGVnZXIgc2l0IGFtZXQgZmVsaXMgYSBlcmF0IGZhdWNpYnVzIGltcGVyZGlldC4gQ3VyYWJpdHVyIHVsdHJpY2llcyBzb2xsaWNpdHVkaW4gb3JjaSwgc2l0IGFtZXQgc2NlbGVyaXNxdWUgbGFjdXMgc2VtcGVyIGF1Y3Rvci4gVXQgZXUgc2FwaWVuIGVzdC4gSW50ZWdlciBwcmV0aXVtIGZlbGlzIGlkIHB1cnVzIHVsbGFtY29ycGVyIHNhZ2l0dGlzLiBTZWQgdWx0cmljaWVzIGp1c3RvIGFjIGFyY3UgdGVtcG9yLCBldCBkYXBpYnVzIHJpc3VzIGFkaXBpc2NpbmcuIEFsaXF1YW0gZGljdHVtIGxpZ3VsYSB2aXRhZSBsb3JlbSBwZWxsZW50ZXNxdWUgZmF1Y2lidXMuIE1hZWNlbmFzIG9kaW8gdGVsbHVzLCBkaWduaXNzaW0gYSBsYWNpbmlhIGFjLCBzb2xsaWNpdHVkaW4gYXQgc2FwaWVuLiBOdW5jIGNvbnNlcXVhdCwgYXJjdSBlZ2V0IHJ1dHJ1bSBoZW5kcmVyaXQsIGFudGUgc2FwaWVuIGZhdWNpYnVzIG1hc3NhLCBlZ2V0IHNvZGFsZXMgbWV0dXMgZXJhdCBzaXQgYW1ldCBudWxsYS4gUXVpc3F1ZSB2aXRhZSBtaSBxdWlzIGF1Z3VlIGRhcGlidXMgZnJpbmdpbGxhLiBOdWxsYSBmZXJtZW50dW0gdGVsbHVzIHF1YW0sIGlkIHRyaXN0aXF1ZSBhcmN1IGxvYm9ydGlzIG5lYy4KCk5hbSBoZW5kcmVyaXQgbmVxdWUgbG9yZW0sIHNlZCBvcm5hcmUgbnVuYyBlbGVtZW50dW0gc2l0IGFtZXQuIFZpdmFtdXMgZmV1Z2lhdCBuaXNsIG5lYyBudWxsYSBkaWN0dW0gcnV0cnVtLiBWaXZhbXVzIG5vbiB1bHRyaWNpZXMgbnVsbGEuIFNlZCBqdXN0byBuaXNpLCBncmF2aWRhIGlkIG5pc2wgZWdldCwgdmVuZW5hdGlzIGRhcGlidXMgbWFzc2EuIFByYWVzZW50IGlkIHZvbHV0cGF0IGVyYXQsIHNlZCB2YXJpdXMgcmlzdXMuIFBoYXNlbGx1cyBpbiBydXRydW0gYXVndWUuIEN1cmFiaXR1ciB1bHRyaWNpZXMgbmliaCBldSBhbGlxdWFtIGFsaXF1YW0uCgpJbnRlZ2VyIGV1IHB1cnVzIHJpc3VzLiBBZW5lYW4gaWFjdWxpcyBudWxsYSBtYXR0aXMgbmlzaSBsb2JvcnRpcyBwb3J0dGl0b3IuIFNlZCBldWlzbW9kIHRlbGx1cyBpZCBtb2xlc3RpZSBldWlzbW9kLiBQZWxsZW50ZXNxdWUgYmxhbmRpdCByaXN1cyBhYyBjb21tb2RvIHJob25jdXMuIFByb2luIHZlbCBjb252YWxsaXMgZW5pbS4gRHVpcyBsYWNpbmlhIG5pYmggbmlzaSwgdml0YWUgc29kYWxlcyBvZGlvIGdyYXZpZGEgYS4gUGhhc2VsbHVzIGN1cnN1cyBpcHN1bSBzZWQgbWF0dGlzIHVsbGFtY29ycGVyLiBDcmFzIGEgbWF0dGlzIHRlbGx1cy4gU2VkIHNlbXBlciBmYWNpbGlzaXMgdGluY2lkdW50LiBTZWQgcG9ydGEgbGFvcmVldCBkdWksIGFjIHZlbmVuYXRpcyBlcmF0IGxhb3JlZXQgdml0YWUuIFBoYXNlbGx1cyB1dCBlZ2VzdGFzIHR1cnBpcy4KClNlZCBsaWd1bGEgc2VtLCBlbGVtZW50dW0gcXVpcyBwb3N1ZXJlIHZpdGFlLCBsdWN0dXMgcXVpcyBuZXF1ZS4gTnVsbGEgZmFjaWxpc2kuIEluIG5lYyBkaWFtIGZhdWNpYnVzLCBwdWx2aW5hciBpcHN1bSBhdCwgc29sbGljaXR1ZGluIGp1c3RvLiBDbGFzcyBhcHRlbnQgdGFjaXRpIHNvY2lvc3F1IGFkIGxpdG9yYSB0b3JxdWVudCBwZXIgY29udWJpYSBub3N0cmEsIHBlciBpbmNlcHRvcyBoaW1lbmFlb3MuIEN1cmFiaXR1ciBzaXQgYW1ldCBxdWFtIHZlbCBvcmNpIGNvbnNlcXVhdCBzYWdpdHRpcyBhdCBuZWMgcmlzdXMuIE51bGxhbSBldCBzZW0gYWMgb3JjaSBmYXVjaWJ1cyBtb2xlc3RpZSBlZ2V0IGx1Y3R1cyBkdWkuIENyYXMgbmVjIG1pIGluIHB1cnVzIGFjY3Vtc2FuIG1vbGVzdGllIGZldWdpYXQgbm9uIHF1YW0uIE51bGxhbSBwaGFyZXRyYSBibGFuZGl0IGVsaXQgdmVsIGRhcGlidXMuIFByYWVzZW50IGluIG9kaW8gYXQgZXJvcyBwb3N1ZXJlIG1hbGVzdWFkYSB2aXRhZSBldCBvZGlvLiBDcmFzIGNvbW1vZG8gdml0YWUgZGlhbSBzZWQgcGxhY2VyYXQuIEluIGhhYyBoYWJpdGFzc2UgcGxhdGVhIGRpY3R1bXN0Lg==";
            inputFormatSelector.DataFormat = DataFormat.Base64;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            outbox.Text = ConversionEngine.Run(
                inbox.Text,
                inputFormatSelector.DataFormat,
                outputFormatSelector.DataFormat,
                operationSelector.Operation);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;
                inbox.Text = ConversionEngine.Load(dialog.FileName, inputFormatSelector.DataFormat);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                ConversionEngine.Save(outbox.Text, dialog.FileName, outputFormatSelector.DataFormat);
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
