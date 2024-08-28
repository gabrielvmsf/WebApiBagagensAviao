using Microsoft.AspNetCore.Mvc;
using WebApplicationBagagens.Dto.HistoricoMovimentacaoDto;
using WebApplicationBagagens.Models;
using WebApplicationBagagens.Services.Bagagem;

namespace WebApplicationBagagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoMovimentacaoController : Controller
    {
        private readonly IHistoricoMovimentacaoInterface _historicoMovimentacaoInterface;

        public HistoricoMovimentacaoController(IHistoricoMovimentacaoInterface historicoMovimentacaoInterface)
        {
            _historicoMovimentacaoInterface = historicoMovimentacaoInterface;
        }

        [HttpPost("cadastrar-historico")]
        public async Task<ActionResult<ResponseModel<HistoricoMovimentacaoModel>>> CadastrarHistoricoMovimentacao(HistoricoMovimentacaoCriacaoDto historicoMovimentacaoCriacaoDto)
        {
            var historico = await _historicoMovimentacaoInterface.CadastrarHistoricoMovimentacao(historicoMovimentacaoCriacaoDto);
            return Ok(historico);
        }

        [HttpGet("listar-historico")]
        public async Task<ActionResult<ResponseModel<List<HistoricoMovimentacaoModel>>>> ListarHistoricoMovimentacao()
        {
            var historicos = await _historicoMovimentacaoInterface.ListarHistoricoMovimentacao();
            return Ok(historicos);
        }

        [HttpGet("listar-historico-bagagem/{bagagemID}")]
        public async Task<ActionResult<ResponseModel<List<HistoricoMovimentacaoModel>>>> ListarHistoricoMovimentacaoBagagem(int bagagemID)
        {
            var historicos = await _historicoMovimentacaoInterface.ListarHistoricoMovimentacaoBagagem(bagagemID);
            return Ok(historicos);
        }

        [HttpGet("consultar-historico/{id}")]
        public async Task<ActionResult<ResponseModel<HistoricoMovimentacaoModel>>> ConsultarHistoricoMovimentacao(int id)
        {
            var historico = await _historicoMovimentacaoInterface.ConsultarHistoricoMovimentacao(id);
            return Ok(historico);
        }

        [HttpPut("atualizar-historico")]
        public async Task<ActionResult<ResponseModel<HistoricoMovimentacaoModel>>> AtualizarHistoricoMovimentacao(HistoricoMovimentacaoEdicaoDto historicoMovimentacaoEdicaoDto)
        {
            var historico = await _historicoMovimentacaoInterface.AtualizarHistoricoMovimentacao(historicoMovimentacaoEdicaoDto);
            return Ok(historico);
        }

        [HttpDelete("deletar-historico/{id}")]
        public async Task<ActionResult<ResponseModel<HistoricoMovimentacaoModel>>> DeletarHistoricoMovimentacao(int id)
        {
            var historico = await _historicoMovimentacaoInterface.DeletarHistoricoMovimentacao(id);
            return Ok(historico);
        }
    }
}
