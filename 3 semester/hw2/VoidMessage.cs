namespace hw2 {
    public class VoidMessage : IMessage {
        public ComputerState Execute(ComputerState server) {
            return server;
        }
    }
}
