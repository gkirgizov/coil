namespace hw2 {
    public class VoidMessage : IMessage {
        public ComputerState GetMessage(ComputerState server) {
            return server;
        }
    }
}
