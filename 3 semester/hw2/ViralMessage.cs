namespace hw2 {
    public class ViralMessage : IMessage {
        public ComputerState Execute(ComputerState server) {
            return new InfectedState();
        }
    }
}
