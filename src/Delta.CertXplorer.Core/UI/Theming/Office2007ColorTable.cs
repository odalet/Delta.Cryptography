/********************************************************************/
/*  Office 2007 Renderer Project                                    */
/*                                                                  */
/*  Use the Office2007Renderer class as a custom renderer by        */
/*  providing it to the ToolStripManager.Renderer property. Then    */
/*  all tool strips, menu strips, status strips etc will be drawn   */
/*  using the Office 2007 style renderer in your application.       */
/*                                                                  */
/*   Author: Phil Wright                                            */
/*  Website: www.componentfactory.com                               */
/*  Contact: phil.wright@componentfactory.com                       */
/********************************************************************/

// Adapted from http://www.codeproject.com/KB/menus/Office2007Renderer.aspx

using System.Drawing;
using System.Windows.Forms;
using System;

namespace Delta.CertXplorer.UI.Theming
{
    /// <summary>
    /// Provide Office 2007 Blue Theme colors
    /// </summary>
    internal sealed class Office2007ColorTable : ProfessionalColorTable
    {
        private static Color contextMenuBack;
        private static Color buttonPressedBegin;
        private static Color buttonPressedEnd;
        private static Color buttonPressedMiddle;
        private static Color buttonSelectedBegin;
        private static Color buttonSelectedEnd;
        private static Color buttonSelectedMiddle;
        private static Color menuItemSelectedBegin;
        private static Color menuItemSelectedEnd;
        private static Color checkBack;
        private static Color gripDark;
        private static Color gripLight;
        private static Color imageMargin;
        private static Color menuBorder;
        private static Color overflowBegin;
        private static Color overflowEnd;
        private static Color overflowMiddle;
        private static Color menuToolBack;
        private static Color separatorDark;
        private static Color separatorLight;
        private static Color statusStripLight;
        private static Color statusStripDark;
        private static Color toolStripBorder;
        private static Color toolStripContentEnd;
        private static Color toolStripBegin;
        private static Color toolStripEnd;
        private static Color toolStripMiddle;
        private static Color buttonBorder;

        private static void InitializeBlueColorScheme()
        {
            contextMenuBack = Color.FromArgb(250, 250, 250);
            buttonPressedBegin = Color.FromArgb(248, 181, 106);
            buttonPressedEnd = Color.FromArgb(255, 208, 134);
            buttonPressedMiddle = Color.FromArgb(251, 140, 60);
            buttonSelectedBegin = Color.FromArgb(255, 255, 222);
            buttonSelectedEnd = Color.FromArgb(255, 203, 136);
            buttonSelectedMiddle = Color.FromArgb(255, 225, 172);
            menuItemSelectedBegin = Color.FromArgb(255, 213, 103);
            menuItemSelectedEnd = Color.FromArgb(255, 228, 145);
            checkBack = Color.FromArgb(255, 227, 149);
            gripDark = Color.FromArgb(111, 157, 217);
            gripLight = Color.FromArgb(255, 255, 255);
            imageMargin = Color.FromArgb(233, 238, 238);
            menuBorder = Color.FromArgb(134, 134, 134);
            overflowBegin = Color.FromArgb(167, 204, 251);
            overflowEnd = Color.FromArgb(101, 147, 207);
            overflowMiddle = Color.FromArgb(167, 204, 251);
            menuToolBack = Color.FromArgb(191, 219, 255);
            separatorDark = Color.FromArgb(154, 198, 255);
            separatorLight = Color.FromArgb(255, 255, 255);
            statusStripLight = Color.FromArgb(215, 229, 247);
            statusStripDark = Color.FromArgb(172, 201, 238);
            toolStripBorder = Color.FromArgb(111, 157, 217);
            toolStripContentEnd = Color.FromArgb(164, 195, 235);
            toolStripBegin = Color.FromArgb(227, 239, 255);
            toolStripEnd = Color.FromArgb(152, 186, 230);
            toolStripMiddle = Color.FromArgb(222, 236, 255);
            buttonBorder = Color.FromArgb(121, 153, 194);
        }

        private static Office2007ColorTable blueScheme = null;

        public static Office2007ColorTable Blue
        {
            get
            {
                if (blueScheme == null)
                    blueScheme = new Office2007ColorTable(InitializeBlueColorScheme);

                return blueScheme;
            }
        }

        /// <summary>
        /// Initialize a new instance of the Office2007ColorTable class.
        /// </summary>
        private Office2007ColorTable(Action initializeColorScheme) => initializeColorScheme();

        /// <summary>
        /// Gets the starting color of the gradient used when the button is pressed down.
        /// </summary>
        public override Color ButtonPressedGradientBegin => buttonPressedBegin;

        /// <summary>
        /// Gets the end color of the gradient used when the button is pressed down.
        /// </summary>
        public override Color ButtonPressedGradientEnd => buttonPressedEnd;

        /// <summary>
        /// Gets the middle color of the gradient used when the button is pressed down.
        /// </summary>
        public override Color ButtonPressedGradientMiddle => buttonPressedMiddle;

        /// <summary>
        /// Gets the starting color of the gradient used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedGradientBegin => buttonSelectedBegin;

        /// <summary>
        /// Gets the end color of the gradient used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedGradientEnd => buttonSelectedEnd;

        /// <summary>
        /// Gets the middle color of the gradient used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedGradientMiddle => buttonSelectedMiddle;

        /// <summary>
        /// Gets the border color to use with ButtonSelectedHighlight.
        /// </summary>
        public override Color ButtonSelectedHighlightBorder => buttonBorder;

        /// <summary>
        /// Gets the solid color to use when the check box is selected and gradients are being used.
        /// </summary>
        public override Color CheckBackground => checkBack;

        /// <summary>
        /// Gets the color to use for shadow effects on the grip or move handle.
        /// </summary>
        public override Color GripDark => gripDark;

        /// <summary>
        /// Gets the color to use for highlight effects on the grip or move handle.
        /// </summary>
        public override Color GripLight => gripLight;

        /// <summary>
        /// Gets the starting color of the gradient used in the image margin of a ToolStripDropDownMenu.
        /// </summary>
        public override Color ImageMarginGradientBegin => imageMargin;

        /// <summary>
        /// Gets the border color or a MenuStrip.
        /// </summary>
        public override Color MenuBorder => menuBorder;

        /// <summary>
        /// Gets the starting color of the gradient used when a top-level ToolStripMenuItem is pressed down.
        /// </summary>
        public override Color MenuItemPressedGradientBegin => toolStripBegin;

        /// <summary>
        /// Gets the end color of the gradient used when a top-level ToolStripMenuItem is pressed down.
        /// </summary>
        public override Color MenuItemPressedGradientEnd => toolStripEnd;

        /// <summary>
        /// Gets the middle color of the gradient used when a top-level ToolStripMenuItem is pressed down.
        /// </summary>
        public override Color MenuItemPressedGradientMiddle => toolStripMiddle;

        /// <summary>
        /// Gets the starting color of the gradient used when the ToolStripMenuItem is selected.
        /// </summary>
        public override Color MenuItemSelectedGradientBegin => menuItemSelectedBegin;

        /// <summary>
        /// Gets the end color of the gradient used when the ToolStripMenuItem is selected.
        /// </summary>
        public override Color MenuItemSelectedGradientEnd => menuItemSelectedEnd;

        /// <summary>
        /// Gets the starting color of the gradient used in the MenuStrip.
        /// </summary>
        public override Color MenuStripGradientBegin => menuToolBack;

        /// <summary>
        /// Gets the end color of the gradient used in the MenuStrip.
        /// </summary>
        public override Color MenuStripGradientEnd => menuToolBack;

        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripOverflowButton.
        /// </summary>
        public override Color OverflowButtonGradientBegin => overflowBegin;

        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripOverflowButton.
        /// </summary>
        public override Color OverflowButtonGradientEnd => overflowEnd;

        /// <summary>
        /// Gets the middle color of the gradient used in the ToolStripOverflowButton.
        /// </summary>
        public override Color OverflowButtonGradientMiddle => overflowMiddle;

        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripContainer.
        /// </summary>
        public override Color RaftingContainerGradientBegin => menuToolBack;

        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripContainer.
        /// </summary>
        public override Color RaftingContainerGradientEnd => menuToolBack;

        /// <summary>
        /// Gets the color to use to for shadow effects on the ToolStripSeparator.
        /// </summary>
        public override Color SeparatorDark => separatorDark;

        /// <summary>
        /// Gets the color to use to for highlight effects on the ToolStripSeparator.
        /// </summary>
        public override Color SeparatorLight => separatorLight;

        /// <summary>
        /// Gets the starting color of the gradient used on the StatusStrip.
        /// </summary>
        public override Color StatusStripGradientBegin => statusStripLight;

        /// <summary>
        /// Gets the end color of the gradient used on the StatusStrip.
        /// </summary>
        public override Color StatusStripGradientEnd => statusStripDark;

        /// <summary>
        /// Gets the border color to use on the bottom edge of the ToolStrip.
        /// </summary>
        public override Color ToolStripBorder => toolStripBorder;

        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripContentPanel.
        /// </summary>
        public override Color ToolStripContentPanelGradientBegin => toolStripContentEnd;

        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripContentPanel.
        /// </summary>
        public override Color ToolStripContentPanelGradientEnd => menuToolBack;

        /// <summary>
        /// Gets the solid background color of the ToolStripDropDown.
        /// </summary>
        public override Color ToolStripDropDownBackground => contextMenuBack;

        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStrip background.
        /// </summary>
        public override Color ToolStripGradientBegin => toolStripBegin;

        /// <summary>
        /// Gets the end color of the gradient used in the ToolStrip background.
        /// </summary>
        public override Color ToolStripGradientEnd => toolStripEnd;

        /// <summary>
        /// Gets the middle color of the gradient used in the ToolStrip background.
        /// </summary>
        public override Color ToolStripGradientMiddle => toolStripMiddle;

        /// <summary>
        /// Gets the starting color of the gradient used in the ToolStripPanel.
        /// </summary>
        public override Color ToolStripPanelGradientBegin => menuToolBack;

        /// <summary>
        /// Gets the end color of the gradient used in the ToolStripPanel.
        /// </summary>
        public override Color ToolStripPanelGradientEnd => menuToolBack;
    }
}
