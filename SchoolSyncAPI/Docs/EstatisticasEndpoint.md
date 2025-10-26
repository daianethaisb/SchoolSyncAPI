# Endpoint de Estatísticas do Dashboard

## Descrição
Este endpoint fornece estatísticas consolidadas do sistema escolar para exibição em dashboards.

## Endpoint

### GET `/api/estatisticas/dashboard`

Retorna estatísticas gerais do sistema incluindo:
- Totais de alunos, responsáveis, turmas, disciplinas e matrículas
- Média geral de notas
- Vagas disponíveis e taxa de ocupação
- Estatísticas detalhadas por turma
- Estatísticas detalhadas por disciplina

## Exemplo de Requisição

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
      "nomeTurma": "9º Ano - Turma Manhã",
      "totalAlunos": 30,
      "capacidadeMaxima": 35,
      "percentualOcupacao": 85.71
    }
  ],
  "estatisticasPorDisciplina": [
    {
      "idDisciplina": 1,
      "nomeDisciplina": "Matemática",
      "mediaGeral": 7.5,
      "totalAvaliacoes": 120
    }
  ]
}
```

## Códigos de Resposta

- **200 OK**: Estatísticas retornadas com sucesso
- **500 Internal Server Error**: Erro ao processar a requisição

## Estrutura de Dados

### DashboardEstatisticasResponse

| Campo | Tipo | Descrição |
|-------|------|-----------|
| totalAlunos | int | Total de alunos cadastrados |
| totalAlunosAtivos | int | Total de alunos ativos |
| totalResponsaveis | int | Total de responsáveis financeiros |
| totalTurmas | int | Total de turmas cadastradas |
| totalTurmasAtivas | int | Total de turmas ativas |
| totalDisciplinas | int | Total de disciplinas |
| totalMatriculas | int | Total de matrículas |
| totalMatriculasAtivas | int | Total de matrículas com situação "Ativa" |
| mediaGeralNotas | decimal | Média geral de todas as notas lançadas |
| vagasDisponiveis | int | Total de vagas disponíveis em turmas ativas |
| taxaOcupacao | decimal | Percentual de ocupação das turmas (0-100) |
| estatisticasPorTurma | array | Lista de estatísticas por turma |
| estatisticasPorDisciplina | array | Lista de estatísticas por disciplina |

### EstatisticaTurmaResponse

| Campo | Tipo | Descrição |
|-------|------|-----------|
| idTurma | int | ID da turma |
| nomeTurma | string | Nome da turma (série + turno) |
| totalAlunos | int | Total de alunos matriculados ativos |
| capacidadeMaxima | int | Capacidade máxima da turma |
| percentualOcupacao | decimal | Percentual de ocupação (0-100) |

### EstatisticaDisciplinaResponse

| Campo | Tipo | Descrição |
|-------|------|-----------|
| idDisciplina | int | ID da disciplina |
| nomeDisciplina | string | Nome da disciplina |
| mediaGeral | decimal | Média geral das notas da disciplina |
| totalAvaliacoes | int | Total de avaliações registradas |

## Observações

- As estatísticas são calculadas em tempo real a partir dos dados atuais do sistema
- A taxa de ocupação é calculada apenas para turmas ativas
- A média geral considera apenas notas com valor informado
- As listas de estatísticas por turma e disciplina são ordenadas por ordem decrescente de ocupação e total de avaliações, respectivamente
