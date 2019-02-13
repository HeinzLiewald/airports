namespace Service.Util {
    public static class Extension {
        public static void CheckIfIsNull(this object valor, string nombreValor) {
            if (valor == null || (valor.GetType() == typeof(string) && string.IsNullOrWhiteSpace(valor.ToString()))) {
                throw new CantBeNullException(nombreValor);
            }
        }
    }
}
