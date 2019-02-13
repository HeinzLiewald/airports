using System;

namespace Service.Util {
    public class CognizantException : Exception {
        public CognizantException(string message) : base(message) { }
        public CognizantException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class CantBeNullException : CognizantException {
        private static string Message_CantBeNull(string parameter) => string.Format("{0} can't be null.", parameter);

        public CantBeNullException(string parameter) : base(Message_CantBeNull(parameter)) { }
    }

    public class AirportNotFoundException : CognizantException {
        private static string Message_AirportNotFound(string airport) => string.Format("{0} not found.", airport);

        public AirportNotFoundException(string airport) : base(Message_AirportNotFound(airport)) { }
    }
}
