using WebApplicationBagagens.Dto.HistoricoMovimentacaoDto;
using WebApplicationBagagens.Models;

namespace WebApplicationBagagens.Services.Bagagem
{
    public interface IHistoricoMovimentacaoInterface
    {
        Task<ResponseModel<List<HistoricoMovimentacaoModel>>> ListarHistoricoMovimentacaoBagagem(int bagagemID);
        Task<ResponseModel<List<HistoricoMovimentacaoModel>>> ListarHistoricoMovimentacao();
        Task<ResponseModel<HistoricoMovimentacaoModel>> ConsultarHistoricoMovimentacao(int id);
        Task<ResponseModel<HistoricoMovimentacaoModel>> CadastrarHistoricoMovimentacao(HistoricoMovimentacaoCriacaoDto historicoMovimentacaoCriacaoDto);
        Task<ResponseModel<HistoricoMovimentacaoModel>> AtualizarHistoricoMovimentacao(HistoricoMovimentacaoEdicaoDto historicoMovimentacaoEdicaoDto);
        Task<ResponseModel<HistoricoMovimentacaoModel>> DeletarHistoricoMovimentacao(int id);
    }
}