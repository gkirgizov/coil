namespace hw2 {
    class ViralMessage : IMessage {
        public ComputerState Execute(ComputerState server) {
            return new InfectedState();
        }
    }
}
