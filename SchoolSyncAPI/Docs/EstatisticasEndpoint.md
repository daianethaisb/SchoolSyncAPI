# Endpoint de Estat�sticas do Dashboard

## Descri��o
Este endpoint fornece estat�sticas consolidadas do sistema escolar para exibi��o em dashboards.

## Endpoint

### GET `/api/estatisticas/dashboard`

Retorna estat�sticas gerais do sistema incluindo:
- Totais de alunos, respons�veis, turmas, disciplinas e matr�culas
- M�dia geral de notas
- Vagas dispon�veis e taxa de ocupa��o
- Estat�sticas detalhadas por turma
- Estat�sticas detalhadas por disciplina

## Exemplo de Requisi��o

```bash
curl -X 'GET' \
  'https://localhost:7144/api/Estatisticas/dashboard' \
  -H 'accept: application/json'
```

## Exemplo de Resposta

```json
{
  "totalAlunos": 150,
  "totalAlunosAtivos": 142,
  "totalResponsaveis": 98,
  "totalTurmas": 12,
  "totalTurmasAtivas": 10,
  "totalDisciplinas": 15,
  "totalMatriculas": 160,
  "totalMatriculasAtivas": 145,
  "mediaGeralNotas": 7.8,
  "vagasDisponiveis": 35,
  "taxaOcupacao": 85.5,
  "estatisticasPorTurma": [
    {
      "idTurma": 1,
      "nomeTurma": "9� Ano - Turma Manh�",
      "totalAlunos": 30,
      "capacidadeMaxima": 35,
      "percentualOcupacao": 85.71
    }
  ],
  "estatisticasPorDisciplina": [
    {
      "idDisciplina": 1,
      "nomeDisciplina": "Matem�tica",
      "mediaGeral": 7.5,
      "totalAvaliacoes": 120
    }
  ]
}
```

## C�digos de Resposta

- **200 OK**: Estat�sticas retornadas com sucesso
- **500 Internal Server Error**: Erro ao processar a requisi��o

## Estrutura de Dados

### DashboardEstatisticasResponse

| Campo | Tipo | Descri��o |
|-------|------|-----------|
| totalAlunos | int | Total de alunos cadastrados |
| totalAlunosAtivos | int | Total de alunos ativos |
| totalResponsaveis | int | Total de respons�veis financeiros |
| totalTurmas | int | Total de turmas cadastradas |
| totalTurmasAtivas | int | Total de turmas ativas |
| totalDisciplinas | int | Total de disciplinas |
| totalMatriculas | int | Total de matr�culas |
| totalMatriculasAtivas | int | Total de matr�culas com situa��o "Ativa" |
| mediaGeralNotas | decimal | M�dia geral de todas as notas lan�adas |
| vagasDisponiveis | int | Total de vagas dispon�veis em turmas ativas |
| taxaOcupacao | decimal | Percentual de ocupa��o das turmas (0-100) |
| estatisticasPorTurma | array | Lista de estat�sticas por turma |
| estatisticasPorDisciplina | array | Lista de estat�sticas por disciplina |

### EstatisticaTurmaResponse

| Campo | Tipo | Descri��o |
|-------|------|-----------|
| idTurma | int | ID da turma |
| nomeTurma | string | Nome da turma (s�rie + turno) |
| totalAlunos | int | Total de alunos matriculados ativos |
| capacidadeMaxima | int | Capacidade m�xima da turma |
| percentualOcupacao | decimal | Percentual de ocupa��o (0-100) |

### EstatisticaDisciplinaResponse

| Campo | Tipo | Descri��o |
|-------|------|-----------|
| idDisciplina | int | ID da disciplina |
| nomeDisciplina | string | Nome da disciplina |
| mediaGeral | decimal | M�dia geral das notas da disciplina |
| totalAvaliacoes | int | Total de avalia��es registradas |

## Observa��es

- As estat�sticas s�o calculadas em tempo real a partir dos dados atuais do sistema
- A taxa de ocupa��o � calculada apenas para turmas ativas
- A m�dia geral considera apenas notas com valor informado
- As listas de estat�sticas por turma e disciplina s�o ordenadas por ordem decrescente de ocupa��o e total de avalia��es, respectivamente
