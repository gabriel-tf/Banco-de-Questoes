using BancoDeQuestoes.DAL;
using BancoDeQuestoes.Dominio;
using BancoDeQuestoes.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BancoDeQuestoes.UI.Controllers
{
    public class QuestaoController : BaseClassController
    {

        // GET: Questao
        public ActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var questao = new QuestaoDAL().Get(Convert.ToInt32(id));
                var questaoModel = ConverterParaQuestaoModel(questao);
                return View(questaoModel);
            }
            return View();
        }
        [Authorize]
        public ActionResult Configurar()
        {
            return View();
        }

        public ActionResult Listar()
        {
            var questaoDAL = new QuestaoDAL();

            var questoes = questaoDAL.ListarQuestoes();

            return View(questoes);

        }

        [HttpGet]
        public ActionResult Crop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crop(QuestaoModel model)
        {
            string imagePath = Server.MapPath("~/" + model.CroppedImagePath);

            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

            //Save file whatever you want

            return View("~/Questao/Listar");
        }

        [HttpGet]
        public ActionResult InserirOuEditar(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var questao = new QuestaoDAL().Get(Convert.ToInt32(id));

                var questaoModel = ConverterParaQuestaoModel(questao);

                return View(questaoModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult InserirOuEditar(QuestaoModel model)
        {
            string imagePath = Server.MapPath("~/" + model.CroppedImagePath);

            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

            //Save file whatever you want

            return View();
        }

        private QuestaoModel ConverterParaQuestaoModel(Questao questao)
        {
            var questaoModel = new QuestaoModel();

            var date = (Convert.ToDateTime(questao.DataCriacao.ToString()));
            String dy = date.Day.ToString();
            String mn = date.Month.ToString();
            String yr = date.Year.ToString();

            var data = dy + "/" + mn + "/" + yr;

            questaoModel.Codigo = questao.QuestaoID;
            questaoModel.Comentario = questao.Comentario;
            questaoModel.Dificuldade = questao.Dificuldade;
            //questaoModel.Disciplina = questao.Disciplina;
            //questaoModel.Assunto = questao.Assunto;
            questaoModel.Enunciado = questao.Enunciado;
            questaoModel.DataCriacao = data;
            questaoModel.Autor = questao.Autor;
            questaoModel.Tipo = questao.Tipo;

            String idItens = "";

            // Subjetiva
            if (questao.Itens.Count == 1)
            {
                var item = questao.Itens.FirstOrDefault();
                var itemQuestao = new ItemQuestaoModel();

                itemQuestao.Codigo = item.Codigo;
                itemQuestao.EhResposta = item.Resposta == 1;

                questaoModel.ItemSubjetiva = itemQuestao;
            }
            else
            {   //Objetiva
                foreach (var item in questao.Itens)
                {
                    var itemQuestao = new ItemQuestaoModel();

                    idItens += item.Codigo.ToString() + ",";
                    itemQuestao.Codigo = item.Codigo;
                    itemQuestao.EhResposta = item.Resposta == 1;
                    itemQuestao.Descricao = item.Descricao;
                    itemQuestao.ComentarioItem = item.ComentarioItem;

                    questaoModel.Itens.Add(itemQuestao);
                }
            }

            questaoModel.IdItens = idItens;

            return questaoModel;
        }

        public JsonResult SalvarDisciplinaOuAssunto(string nomeDisc, string nomeAssunt, int idDisc, string graus, string anos)
        {
            DisciplinaDAL disciplinaDAL = new DisciplinaDAL();
            AssuntoDAL assuntoDAL = new AssuntoDAL();
            try
            {

                Disciplina disc = disciplinaDAL.Get(idDisc);

                if (nomeDisc != "")
                {
                    Disciplina disciplina = new Disciplina();
                    disciplina.Descricao = nomeDisc;

                    foreach (var ano in anos.Split(';'))
                    {
                        try
                        {
                            if (ano != "")
                            {
                                Ano anoDisciplina = new Ano();
                                anoDisciplina.AnoID = Convert.ToInt32(ano);
                                disciplina.Anos.Add(anoDisciplina);
                            }
                        }
                        catch (Exception ex)
                        {
                            return Json("Erro de comunicação com o banco de dados. - " + ex.Message);
                        }
                    }

                    foreach (var grau in graus.Split(';'))
                    {
                        try
                        {
                            if (grau != "")
                            {
                                Grau grauDisciplina = new Grau();
                                grauDisciplina.GrauID = Convert.ToInt32(grau);
                                disciplina.Graus.Add(grauDisciplina);
                            }
                        }
                        catch (Exception ex)
                        {
                            return Json("Erro de comunicação com o banco de dados. - " + ex.Message);
                        }
                    }

                    disciplinaDAL.SaveOrUpdate(disciplina);
                }

                if (nomeAssunt != "")
                {
                    Assunto assunto = new Assunto();
                    assunto.Descricao = nomeAssunt;
                    assunto.Disciplina = disc;

                    foreach (var ano in anos.Split(';'))
                    {
                        try
                        {
                            if (ano != "")
                            {
                                Ano anoAssunto = new Ano();
                                anoAssunto.AnoID = Convert.ToInt32(ano);
                                assunto.Anos.Add(anoAssunto);
                            }
                        }
                        catch (Exception ex)
                        {
                            return Json("Erro de comunicação com o banco de dados. - " + ex.Message);
                        }
                    }

                    foreach (var grau in graus.Split(';'))
                    {
                        try
                        {
                            if (grau != "")
                            {
                                Grau grauAssunto = new Grau();
                                grauAssunto.GrauID = Convert.ToInt32(grau);
                                assunto.Graus.Add(grauAssunto);
                            }
                        }
                        catch (Exception ex)
                        {
                            return Json("Erro de comunicação com o banco de dados. - " + ex.Message);
                        }
                    }

                    assuntoDAL.SaveOrUpdate(assunto);
                }
                return Json("");
            }
            catch (Exception)
            {
                return Json("Erro");
            }

        }

        public JsonResult SalvarQuestao(int idQuestao, int idSubjetiva, string idItens, string enunciado, string comentario,
                          int count, string dificuldade, int idDisciplina, int idAssunto, string tipo, string itensRespostas,
                          string itensComentarios, int resposta)
        {
            QuestaoDAL questaoDAL = new QuestaoDAL();
            DisciplinaDAL discDAL = new DisciplinaDAL();
            AssuntoDAL assuntDAL = new AssuntoDAL();
            try
            {
                Questao questao = questaoDAL.Get(idQuestao);
                Disciplina disc = discDAL.Get(idDisciplina);
                Assunto assunto = assuntDAL.Get(idAssunto);

                if (questao == null)
                {
                    questao = new Questao();
                }
                questao.Enunciado = enunciado;
                questao.DataCriacao = DateTime.Now;
                questao.Comentario = comentario;
                questao.Dificuldade = dificuldade;
                //questao.Disciplina = disc;
                questao.Tipo = tipo;
                //questao.Assunto = assunto;
                questao.Autor = Util.RetornarUsuarioLogado();

                questaoDAL.SaveOrUpdate(questao);

                ItemQuestaoDAL itemQuestaoDAL = new ItemQuestaoDAL();

                if (tipo == "subjetiva")
                {
                    try
                    {
                        ItemQuestao itemQuestao = itemQuestaoDAL.Get(idSubjetiva);
                        if (itemQuestao == null)
                        {
                            itemQuestao = new ItemQuestao();
                        }

                        //itemQuestao.Descricao = subjetiva;
                        itemQuestao.Resposta = 1;
                        itemQuestao.Questao = questao;
                        itemQuestaoDAL.SaveOrUpdate(itemQuestao);
                    }
                    catch (Exception)
                    {
                        return Json("Erro");
                    }
                }
                else
                {
                    try
                    {
                        if (idItens == "")
                        {
                            switch (count)
                            {
                                case 2: idItens = "0,0";
                                    break;
                                case 3: idItens = "0,0,0";
                                    break;
                                case 4: idItens = "0,0,0,0";
                                    break;
                                case 5: idItens = "0,0,0,0,0";
                                    break;
                            }
                        }

                        int idItem = 0;
                        int i = 0;
                        int j = 0;
                        string itemComentario;
                        foreach (var respostaItem in itensRespostas.Split(','))
                        {
                            if (String.IsNullOrEmpty(respostaItem)) break;

                            idItem = Convert.ToInt32(idItens.Split(',')[i]);
                            itemComentario = Convert.ToString(itensComentarios.Split(',')[j]);

                            ItemQuestao itemQuestao = itemQuestaoDAL.Get(idItem);

                            if (itemQuestao == null)
                            {
                                itemQuestao = new ItemQuestao();
                            }

                            if (resposta == (i + 1))
                            {
                                itemQuestao.Resposta = 1;
                            }
                            else
                            {
                                itemQuestao.Resposta = 0;
                            }

                            itemQuestao.Descricao = respostaItem;
                            itemQuestao.ComentarioItem = itemComentario;
                            itemQuestao.Questao = questao;

                            itemQuestaoDAL.SaveOrUpdate(itemQuestao);

                            i++;
                            j++;
                        }
                    }
                    catch (Exception)
                    {
                        return Json("Erro");
                    }
                }

                return Json("");
            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public JsonResult ListarQuestoes()
        {
            QuestaoDAL questaoDAL = new QuestaoDAL();

            var a = ((BancoDeQuestoes.Dominio.Usuario)Session["user"]).Nome;

            var questoes = questaoDAL.ListarQuestoes();

            var questoesmodel = new List<QuestaoModel>();

            foreach (var questao in questoes)
            {
                var questaomodel = new QuestaoModel();
                var date = (Convert.ToDateTime(questao.DataCriacao.ToString()));
                String dy = date.Day.ToString();
                String mn = date.Month.ToString();
                String yr = date.Year.ToString();

                var data = dy + "/" + mn + "/" + yr;

                questaomodel.Codigo = questao.QuestaoID;
                questaomodel.Enunciado = questao.EnunciadoCurto;
                questaomodel.Tipo = questao.Tipo;
                questaomodel.Dificuldade = questao.Dificuldade;
                questaomodel.DataCriacao = data;
                questaomodel.Autor = questao.Autor;

                questoesmodel.Add(questaomodel);
            }

            return Json(questoesmodel);
        }

        public JsonResult ListarGraus()
        {
            try
            {
                var grauDAL = new GrauDAL();
                var graus = grauDAL.RetornarGraus();

                var grauModel = new List<GrauModel>();

                foreach (var grau in graus)
                {
                    var graumodel = new GrauModel();
                    graumodel.Descricao = grau.Descricao;
                    graumodel.GrauID = grau.GrauID;

                    grauModel.Add(graumodel);
                }

                return Json(grauModel);
            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public JsonResult ListarAnos()
        {
            try
            {
                var anoDAL = new AnoDAL();
                var anos = anoDAL.RetornarAnos();

                var anoModel = new List<AnoModel>();

                foreach (var ano in anos)
                {
                    var anomodel = new AnoModel();
                    anomodel.Descricao = ano.Descricao;
                    anomodel.AnoID = ano.AnoID;

                    anoModel.Add(anomodel);
                }

                return Json(anoModel);
            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public JsonResult ListarAnosConfigurar(string grauSelected)
        {

            var anoDAL = new AnoDAL();
            var anos = new List<Ano>();
            var anoModel = new List<AnoModel>();

            foreach (var id in grauSelected.Split(','))
            {

                try
                {
                    if (id == "1")
                    {
                        anos = anoDAL.RetornarEnsinoFundamental();
                    }
                    if (id == "2")
                    {
                        anos = anoDAL.RetornarEnsinoMedio();
                    }
                    if (id == "3")
                    {
                        anos = anoDAL.RetornarEnsinoSuperior();
                    }

                    foreach (var ano in anos)
                    {
                        var anomodel = new AnoModel();
                        anomodel.Descricao = ano.Descricao;
                        anomodel.AnoID = ano.AnoID;

                        anoModel.Add(anomodel);
                    }


                }
                catch (Exception)
                {
                    return Json("Erro");
                }
            }
            return Json(anoModel);
        }
        
        public JsonResult AnosConfigurar(string ids)
        {
            
                var anoDAL = new AnoDAL();
                var anos = new List<Ano>();
                var anoModel = new List<AnoModel>();

                foreach (var id in ids.Split(','))
                {

                    try
                    {
                        if (id == "1")
                        {
                            anos = anoDAL.RetornarEnsinoFundamental();
                        }
                        if (id == "2")
                        {
                            anos = anoDAL.RetornarEnsinoMedio();
                        }
                        if (id == "3")
                        {
                            anos = anoDAL.RetornarEnsinoSuperior();
                        }

                        foreach (var ano in anos)
                        {
                            var anomodel = new AnoModel();
                            anomodel.Descricao = ano.Descricao;
                            anomodel.AnoID = ano.AnoID;

                            anoModel.Add(anomodel);
                        }

                        
                    }
                    catch (Exception)
                    {
                        return Json("Erro");
                    }
                }
                return Json(anoModel);
        }

        public JsonResult ListarDisciplinas(int anoSelected)
        {
            try
            {
                var disciplinaDAL = new DisciplinaDAL();
                var disciplinas = new List<Disciplina>();
                switch (anoSelected)
                {
                    case 0:
                        disciplinas = disciplinaDAL.RetornarDisciplinas();
                        break;
                    case 1:
                        disciplinas = disciplinaDAL.RetornarPrimeiroFundamental();
                        break;
                    case 2:
                        disciplinas = disciplinaDAL.RetornarSegundoFundamental();
                        break;
                    case 3:
                        disciplinas = disciplinaDAL.RetornarTerceiroFundamental();
                        break;
                    case 4:
                        disciplinas = disciplinaDAL.RetornarQuartoFundamental();
                        break;
                    case 5:
                        disciplinas = disciplinaDAL.RetornarQuintoFundamental();
                        break;
                    case 6:
                        disciplinas = disciplinaDAL.RetornarSextoFundamental();
                        break;
                    case 7:
                        disciplinas = disciplinaDAL.RetornarSetimoFundamental();
                        break;
                    case 8:
                        disciplinas = disciplinaDAL.RetornarOitavoFundamental();
                        break;
                    case 9:
                        disciplinas = disciplinaDAL.RetornarNonoFundamental();
                        break;
                    case 10:
                        disciplinas = disciplinaDAL.RetornarPrimeiroMedio();
                        break;
                    case 11:
                        disciplinas = disciplinaDAL.RetornarSegundoMedio();
                        break;
                    case 12:
                        disciplinas = disciplinaDAL.RetornarTerceiroMedio();
                        break;
                }
                
                var disciplinaModel = new List<DisciplinaModel>();

                foreach (var disciplina in disciplinas)
                {
                    var disciplinamodel = new DisciplinaModel();
                    disciplinamodel.Descricao = disciplina.Descricao;
                    disciplinamodel.DisciplinaID = disciplina.DisciplinaID;

                    disciplinaModel.Add(disciplinamodel);
                }
                return Json(disciplinaModel);
            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public JsonResult ListarAssuntos(int disciplinaSelected)
        {
            try
            {
                var assuntoDAL = new AssuntoDAL();
                var assuntos = assuntoDAL.RetornarAssuntos();

                var assuntoModel = new List<AssuntoModel>();

                foreach (var assunto in assuntos)
                {
                    int disciplina_id = Convert.ToInt32(assunto.Disciplina.DisciplinaID);
                    
                    if (disciplina_id == disciplinaSelected) {
                        var assuntomodel = new AssuntoModel();
                        assuntomodel.Descricao = assunto.Descricao;
                        assuntomodel.AssuntoID = assunto.AssuntoID;

                        assuntoModel.Add(assuntomodel);
                    }
                }

                return Json(assuntoModel);
            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public JsonResult GrausDisc(string idDisciplina)
        {
            try
            {
                if (String.IsNullOrEmpty(idDisciplina)) { 
                    return Json("selecione"); 
                }
                else
                {
                    var grauDAL = new GrauDAL();
                    var graus = grauDAL.RetornaGrausDisc(Convert.ToInt32(idDisciplina));
                    var grauModel = new List<GrauModel>();

                    if (graus != null)
                    {
                        foreach (var grau in graus)
                        {
                            var graumodel = new GrauModel();
                            graumodel.Descricao = grau.Descricao;
                            graumodel.GrauID = grau.GrauID;

                            grauModel.Add(graumodel);
                        }

                    }
                    return Json(grauModel);
                }
            }
            catch (Exception)
            {
                return Json("Erro");
            }

        }

        public JsonResult AnosDisc(string idDiscAno)
        {
            try
            {
                if (String.IsNullOrEmpty(idDiscAno)) { 
                    return Json("selecione"); 
                }
                else
                {
                    var anoDAL = new AnoDAL();
                    var anos = anoDAL.RetornaAnosDisc(Convert.ToInt32(idDiscAno));
                    var anoModel = new List<AnoModel>();

                    if (anos != null)
                    {
                        foreach (var ano in anos)
                        {
                            var anomodel = new AnoModel();
                            anomodel.Descricao = ano.Descricao;
                            anomodel.AnoID = ano.AnoID;

                            anoModel.Add(anomodel);
                        }

                    }
                    return Json(anoModel);
                }
            }
            catch (Exception)
            {
                return Json("Erro");
            }

        }


        public JsonResult ValidarUsuario(string autorId, string userSessionId)
        {
            try
            {
                if (autorId != null)
                {
                    if (autorId != userSessionId)
                    {
                        return Json("");
                    }
                }
                return Json("ok");
            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public JsonResult RemoverQuestoes(string ids)
        {

            QuestaoDAL questaoDAL = new QuestaoDAL();

            foreach (var id in ids.Split(';'))
            {
                if (String.IsNullOrEmpty(id)) break;

                try
                {
                    var questaoParaRemover = questaoDAL.Get(Convert.ToInt32(id));
                    questaoParaRemover.DataDelecao = DateTime.Now;
                    questaoDAL.SaveOrUpdate(questaoParaRemover);
                    //questaoDAL.Delete(questaoParaRemover);
                }
                catch (Exception ex)
                {
                    return Json("Erro de comunicação com o banco de dados. - " + ex.Message);
                }
            }
            return Json("");
        }

    }
}
