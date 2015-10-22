using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Incapsulates specific for IGlyphLogic behavior.
    /// </summary>
    public abstract class ClickTool {

        public virtual IAction MouseDown(MouseEventArgs e) => defaultReturning;

        public virtual IAction MouseMove(MouseEventArgs e) => defaultReturning;

        public virtual IAction MouseUp(MouseEventArgs e) => defaultReturning;

        /// <summary>
        /// Returns short info about the tool.
        /// </summary>
        public virtual string Info { get; protected set; }


        public void ChangeTool(object sender, System.EventArgs args) => parent.CurrentTool = this;
        
        protected IGlyphLogic parent;
        protected VoidAction defaultReturning = new VoidAction();
    }
}
