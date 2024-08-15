using Microsoft.EntityFrameworkCore;
using WebApplicationBagagens.Data;
using WebApplicationBagagens.Dto.Autor;
using WebApplicationBagagens.Models;

namespace WebApplicationBagagens.Services.Bagagem
{
    public class BagagemService : IBagagemInterface
    {
        private readonly AppDbContext _context;

        public BagagemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<BagagemModel>> AtualizarBagagem(BagagemEdicaoDto bagagemEdicaoDto)
        {
            ResponseModel<BagagemModel> resposta = new ResponseModel<BagagemModel>();

            try
            {
                var bagagem = await _context.Bagagens.FirstOrDefaultAsync(bagagemBanco => bagagemBanco.Id == bagagemEdicaoDto.Id);

                if (bagagem == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                bagagem.VooID = bagagemEdicaoDto.VooID;
                bagagem.Peso = bagagemEdicaoDto.Peso;
                bagagem.Status = bagagemEdicaoDto.Status;
                bagagem.DataRegistro = bagagemEdicaoDto.DataRegistro;
                bagagem.Tipo = bagagemEdicaoDto.Tipo;
                bagagem.Dimensoes = bagagemEdicaoDto.Dimensoes;
                bagagem.PassageiroID = bagagemEdicaoDto.PassageiroID;
                bagagem.Observacoes = bagagemEdicaoDto.Observacoes;

                _context.Update(bagagem);

                await _context.SaveChangesAsync();

                resposta.Dados = bagagem;
                resposta.Mensagem = "Bagagem atualizada com sucesso!";
                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<BagagemModel>> AtualizarStatusBagagem(int id, string status)
        {
            ResponseModel<BagagemModel> resposta = new ResponseModel<BagagemModel>();

            try
            {
                var bagagem = await _context.Bagagens.FirstOrDefaultAsync(bagagemBanco => bagagemBanco.Id == id);

                if (bagagem == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                bagagem.Status = status;

                _context.Update(bagagem);

                await _context.SaveChangesAsync();

                resposta.Dados = bagagem;
                resposta.Mensagem = "Status da bagagem atualizada com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<BagagemModel>> CadastrarBagagem(BagagemCriacaoDto bagagemCriacaoDto)
        {
            ResponseModel<BagagemModel> resposta = new ResponseModel<BagagemModel>();

            try
            {
                var bagagem = new BagagemModel
                {
                    VooID = bagagemCriacaoDto.VooID,
                    Peso = bagagemCriacaoDto.Peso,
                    Status = bagagemCriacaoDto.Status,
                    LocalizacaoAtual = bagagemCriacaoDto.LocalizacaoAtual,
                    DataRegistro = bagagemCriacaoDto.DataRegistro,
                    Tipo = bagagemCriacaoDto.Tipo,
                    Dimensoes = bagagemCriacaoDto.Dimensoes,
                    PassageiroID = bagagemCriacaoDto.PassageiroID,
                    Observacoes = bagagemCriacaoDto.Observacoes
                };

                _context.Bagagens.Add(bagagem);
                await _context.SaveChangesAsync();

                resposta.Dados = bagagem;
                resposta.Mensagem = "Bagagem cadastrada com sucesso!";
                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }   
        }

        public async Task<ResponseModel<BagagemModel>> ConsultarBagagem(int id)
        {
            ResponseModel<BagagemModel> resposta = new ResponseModel<BagagemModel>();

            try
            {
                var bagagem = await _context.Bagagens.FirstOrDefaultAsync(bagagemBanco => bagagemBanco.Id == id);

                if (bagagem == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = bagagem;
                resposta.Mensagem = "Bagagem locaalizada com sucesso!";
                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<BagagemModel>> DeletarBagagem(int id)
        {
            ResponseModel<BagagemModel> resposta = new ResponseModel<BagagemModel>();

            try
            {
                var bagagem = await _context.Bagagens.FirstOrDefaultAsync(bagagemBanco => bagagemBanco.Id == id);

                if (bagagem == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                _context.Bagagens.Remove(bagagem);

                resposta.Dados = bagagem;
                resposta.Mensagem = "Bagagem deletada com sucesso!";
                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<BagagemModel>>> ListarBagagensVoo(int vooID)
        {
            ResponseModel<List<BagagemModel>> resposta = new ResponseModel<List<BagagemModel>>();
            
            try
            {
                var bagagens = await _context.Bagagens.Where(bagagemBanco => bagagemBanco.VooID == vooID).ToListAsync();

                resposta.Dados = bagagens;
                resposta.Mensagem = "Bagagens listadas com sucesso!";

                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<BagagemModel>>> ListarTodasBagagens()
        {
            ResponseModel<List<BagagemModel>> resposta = new ResponseModel<List<BagagemModel>>();

            try
            {
                var bagagens = await _context.Bagagens.ToListAsync();

                resposta.Dados = bagagens;
                resposta.Mensagem = "Bagagens listadas com sucesso!";

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
