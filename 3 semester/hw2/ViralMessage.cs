namespace hw2 {
    public class ViralMessage : IMessage {
        public ComputerState GetMessage(ComputerState server) {
            return new InfectedState();
        }
    }
}
