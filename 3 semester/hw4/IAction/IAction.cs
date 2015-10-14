namespace hw4 {
    /// <summary>
    /// Incapsulates all relevant information about actions
    /// for their executing and unexecuting.
    /// </summary>
    public interface IAction {
        void Execute();
        void Unexecute();
    }
}
