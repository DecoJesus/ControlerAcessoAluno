using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlerAcessoAluno.Models
{
    // Classe MatriculaAluno vai ter os dados da tabela Aluno "Nome, RM, Data de Nascimento, Sexo" e Cod_turma que é da tabela turma 
    //atráves de "Cod_turma" pegaremos outros dados da bela turma que será exibido no formulário de cadastro de aluno

    public class MatriculaAluno
    {
        public string NOME { get; set; }
        public string RM { get; set; } 


        [DataType(DataType.Date)]       // Com esse formato eu não precisarei digitar a data apena escolho a data em um calendário e com essa formatação também não pegaremos a hora somente a data
        public DateTime DATA_NASCIMENTO { get; set; }
        public string SEXO { get; set; }
        public int COD_TURMA { get; set; } //Depois pega os outros dados apartir desse

        public TB_ALUNO TB_ALUNO
        {
            get
            {
                return new TB_ALUNO
                {
                    NOME = this.NOME,
                    RM = this.RM,
                    SEXO = this.SEXO,
                    DATA_NASCIMENTO = this.DATA_NASCIMENTO,


                };

            }
        }

    }
}