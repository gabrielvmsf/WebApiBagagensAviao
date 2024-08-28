namespace WebApplicationBagagens.Models
{
    public class HistoricoMovimentacaoModel
    {
        public int Id { get; set; } // Identificador único
        public int BagagemID { get; set; } // Identificador da bagagem
        public string Localizacao_Antiga { get; set; } // Localização antiga da bagagem
        public string Localizacao_Nova { get; set; } // Localização nova da bagagem
        public DateTime DataHora { get; set; } // Data e hora da movimentação
        public string Status { get; set; } // Status da movimentação, como transferida para área de bagagens, carregada no compartimento do avião
    }
}
