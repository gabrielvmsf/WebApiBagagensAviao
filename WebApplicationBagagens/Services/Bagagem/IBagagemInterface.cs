using WebApplicationBagagens.Dto.Autor;
using WebApplicationBagagens.Models;

namespace WebApplicationBagagens.Services.Bagagem
{
    public interface IBagagemInterface
    {
        Task<ResponseModel<List<BagagemModel>>> ListarBagagensVoo(int vooID);
        Task<ResponseModel<List<BagagemModel>>> ListarTodasBagagens();
        Task<ResponseModel<BagagemModel>> ConsultarBagagem(int id);
        Task<ResponseModel<BagagemModel>> CadastrarBagagem(BagagemCriacaoDto bagagemCriacaoDto);
        Task<ResponseModel<BagagemModel>> AtualizarBagagem(BagagemEdicaoDto bagagemEdicaoDto);
        Task<ResponseModel<BagagemModel>> DeletarBagagem(int id);
        Task<ResponseModel<BagagemModel>> AtualizarStatusBagagem(int id, string status);
    }
}
