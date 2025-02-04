namespace GerenciamentoTarefas.Application.Utils
{
    public static class DateUtils
    {
        public static bool DataMaiorQueAtual(DateTime data)
        {
            return data.Date >= DateTime.Now.Date;
        }
    }
}
