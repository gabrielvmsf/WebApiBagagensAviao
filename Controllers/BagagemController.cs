using Microsoft.AspNetCore.Mvc;
using WebApplicationBagagens.Dto.Autor;
using WebApplicationBagagens.Models;
using WebApplicationBagagens.Services.Bagagem;

namespace WebApplicationBagagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagagemController : Controller
    {
        private readonly IBagagemInterface _bagagemInterface;

        public BagagemController(IBagagemInterface bagagemInterface)
        {
            _bagagemInterface = bagagemInterface;
        }

        [HttpPost("cadastrar-bagagem")]
        public async Task<ActionResult<ResponseModel<BagagemModel>>> CadastrarBagagem(BagagemCriacaoDto bagagemCriacaoDto)
        {
            var bagagem = await _bagagemInterface.CadastrarBagagem(bagagemCriacaoDto);
            return Ok(bagagem);
        }

        [HttpGet("listar-bagagens-voo/{vooID}")]
        public async Task<ActionResult<ResponseModel<List<BagagemModel>>>> ListarBagagensVoo(int vooID)
        {
            var autores = await _bagagemInterface.ListarBagagensVoo(vooID);
            return Ok(autores);
        }

        [HttpGet("listar-todas-bagagens")]
        public async Task<ActionResult<ResponseModel<List<BagagemModel>>>> ListarTodasBagagens()
        {
            var bagagens = await _bagagemInterface.ListarTodasBagagens();
            return Ok(bagagens);
        }

        [HttpGet("consultar-bagagem/{idBagagem}")]
        public async Task<ActionResult<ResponseModel<BagagemModel>>> ConsultarBagagem(int idBagagem)
        {
            var bagagem = await _bagagemInterface.ConsultarBagagem(idBagagem);
            return Ok(bagagem);
        }

        [HttpPut("atualizar-bagagem")]
        public async Task<ActionResult<ResponseModel<BagagemModel>>> AtualizarBagagem(BagagemEdicaoDto bagagemEdicaoDto)
        {
            var bagagem = await _bagagemInterface.AtualizarBagagem(bagagemEdicaoDto);
            return Ok(bagagem);
        }

        [HttpPut("atualizar-status-bagagem/{idBagagem}/{status}")]
        public async Task<ActionResult<ResponseModel<BagagemModel>>> AtualizarStatusBagagem(int idBagagem, string status)
        {
            var bagagem = await _bagagemInterface.AtualizarStatusBagagem(idBagagem, status);
            return Ok(bagagem);
        }

        [HttpDelete("deletar-bagagem/{idBagagem}")]
        public async Task<ActionResult<ResponseModel<BagagemModel>>> DeletarBagagem(int idBagagem)
        {
            var bagagem = await _bagagemInterface.DeletarBagagem(idBagagem);
            return Ok(bagagem);
        }

    }
}
