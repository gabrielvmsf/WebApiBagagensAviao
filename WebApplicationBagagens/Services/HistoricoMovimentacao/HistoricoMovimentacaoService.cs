using Microsoft.EntityFrameworkCore;
using WebApplicationBagagens.Data;
using WebApplicationBagagens.Dto.HistoricoMovimentacaoDto;
using WebApplicationBagagens.Models;

namespace WebApplicationBagagens.Services.Bagagem
{
    public class HistoricoMovimentacaoService : IHistoricoMovimentacaoInterface
    {
        private readonly AppDbContext _context;

        public HistoricoMovimentacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<HistoricoMovimentacaoModel>> AtualizarHistoricoMovimentacao(HistoricoMovimentacaoEdicaoDto historicoMovimentacaoEdicaoDto)
        {
            ResponseModel<HistoricoMovimentacaoModel> resposta = new ResponseModel<HistoricoMovimentacaoModel>();

            try
            {
                var historico = await _context.HistoricoMovimentacoes
                    .FirstOrDefaultAsync(h => h.Id == historicoMovimentacaoEdicaoDto.Id);

                if (historico == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                historico.BagagemID = historicoMovimentacaoEdicaoDto.BagagemID;
                historico.Localizacao_Antiga = historicoMovimentacaoEdicaoDto.Localizacao_Antiga;
                historico.Localizacao_Nova = historicoMovimentacaoEdicaoDto.Localizacao_Nova;
                historico.DataHora = historicoMovimentacaoEdicaoDto.DataHora;
                historico.Status = historicoMovimentacaoEdicaoDto.Status;

                var bagagem = await _context.Bagagens
                    .Include(b => b.HistoricoMovimentacao)
                    .FirstOrDefaultAsync(b => b.Id == historico.BagagemID);

                if (bagagem == null)
                {
                    resposta.Mensagem = "Bagagem não encontrada!";
                    return resposta;
                }

                bagagem.LocalizacaoAtual = historico.Localizacao_Nova;

                bagagem.HistoricoMovimentacao.Add(historico);

                _context.Update(bagagem);
                await _context.SaveChangesAsync();

                resposta.Dados = historico;
                resposta.Mensagem = "Histórico de movimentação atualizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<HistoricoMovimentacaoModel>> CadastrarHistoricoMovimentacao(HistoricoMovimentacaoCriacaoDto historicoMovimentacaoCriacaoDto)
        {
            ResponseModel<HistoricoMovimentacaoModel> resposta = new ResponseModel<HistoricoMovimentacaoModel>();

            try
            {
                var historico = new HistoricoMovimentacaoModel
                {
                    BagagemID = historicoMovimentacaoCriacaoDto.BagagemID,
                    Localizacao_Antiga = historicoMovimentacaoCriacaoDto.Localizacao_Antiga,
                    Localizacao_Nova = historicoMovimentacaoCriacaoDto.Localizacao_Nova,
                    DataHora = historicoMovimentacaoCriacaoDto.DataHora,
                    Status = historicoMovimentacaoCriacaoDto.Status
                };

                var bagagem = await _context.Bagagens
                    .Include(b => b.HistoricoMovimentacao)
                    .FirstOrDefaultAsync(b => b.Id == historico.BagagemID);

                if (bagagem == null)
                {
                    resposta.Mensagem = "Bagagem não encontrada!";
                    return resposta;
                }

                bagagem.LocalizacaoAtual = historico.Localizacao_Nova;

                bagagem.HistoricoMovimentacao.Add(historico);

                _context.HistoricoMovimentacoes.Add(historico);
                _context.Update(bagagem);
                await _context.SaveChangesAsync();

                resposta.Dados = historico;
                resposta.Mensagem = "Histórico de movimentação cadastrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<HistoricoMovimentacaoModel>> ConsultarHistoricoMovimentacao(int id)
        {
            ResponseModel<HistoricoMovimentacaoModel> resposta = new ResponseModel<HistoricoMovimentacaoModel>();

            try
            {
                var historico = await _context.HistoricoMovimentacoes.FirstOrDefaultAsync(h => h.Id == id);

                if (historico == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = historico;
                resposta.Mensagem = "Histórico de movimentação localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<HistoricoMovimentacaoModel>> DeletarHistoricoMovimentacao(int id)
        {
            ResponseModel<HistoricoMovimentacaoModel> resposta = new ResponseModel<HistoricoMovimentacaoModel>();

            try
            {
                var historico = await _context.HistoricoMovimentacoes.FirstOrDefaultAsync(h => h.Id == id);

                if (historico == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                var bagagem = await _context.Bagagens
                    .Include(b => b.HistoricoMovimentacao)
                    .FirstOrDefaultAsync(b => b.Id == historico.BagagemID);

                if (bagagem != null)
                {
                    bagagem.HistoricoMovimentacao.Remove(historico);
                    _context.Update(bagagem);
                }

                _context.HistoricoMovimentacoes.Remove(historico);
                await _context.SaveChangesAsync();

                resposta.Dados = historico;
                resposta.Mensagem = "Histórico de movimentação deletado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<HistoricoMovimentacaoModel>>> ListarHistoricoMovimentacao()
        {
            ResponseModel<List<HistoricoMovimentacaoModel>> resposta = new ResponseModel<List<HistoricoMovimentacaoModel>>();

            try
            {
                var historicos = await _context.HistoricoMovimentacoes.ToListAsync();

                resposta.Dados = historicos;
                resposta.Mensagem = "Históricos de movimentação listados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<HistoricoMovimentacaoModel>>> ListarHistoricoMovimentacaoBagagem(int bagagemID)
        {
            ResponseModel<List<HistoricoMovimentacaoModel>> resposta = new ResponseModel<List<HistoricoMovimentacaoModel>>();

            try
            {
                var historicos = await _context.HistoricoMovimentacoes
                    .Where(h => h.BagagemID == bagagemID)
                    .ToListAsync();

                resposta.Dados = historicos;
                resposta.Mensagem = "Históricos de movimentação para a bagagem listados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
