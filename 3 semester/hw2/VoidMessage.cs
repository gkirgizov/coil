namespace hw2 {
    class VoidMessage : IMessage {
        public ComputerState Execute(ComputerState server) {
            return server;
        }
    }
}
