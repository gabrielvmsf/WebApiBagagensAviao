using System.Text.Json.Serialization;

namespace WebApplicationBagagens.Models
{
    public class BagagemModel
    {
        public int Id { get; set; } // Identificador único
        public int PassageiroID { get; set; } // Identificador do passageiro
        public int VooID { get; set; } // Identificador do voo
        public double Peso { get; set; } // Em kg
        public string Dimensoes { get; set; } // Comprimento x Largura x Altura
        public string Tipo { get; set; } // Mala de mão, mala de porão, mochila, item frágil, item especial, etc.
        public string Status { get; set; } // Em check-in, despachada, a bordo, extraviada, etc.
        public DateTime DataRegistro { get; set; } // Data de registro da bagagem
        public string LocalizacaoAtual { get; set; } // Localização atual da bagagem
        public string? Observacoes { get; set; } // Observações adicionais, como itens especiais ou condições de manuseio

        [JsonIgnore]
        public ICollection<HistoricoMovimentacaoModel> HistoricoMovimentacao { get; set; }
    }
}