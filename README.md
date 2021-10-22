<h1 align="center">
    API Dindin.Web
  
## 💻 Sobre o projeto

Dindin = Regra de Negócio / Repositório

Dindin.Web = Api REST

## ▶️ Executando o projeto

dindin/backend/Dindin
  
Solução: Dindin.sln	
	
backend/Dindin.Dominio/DAO/ConexaoMysql.cs.cs
	
Atribui os valores na string connectionString:
	
static string connectionString = "datasource=;port=3306;username=;password=;database=;SslMode=none";

## 🌍 Endpoints

### 1. GET /api/Curso

Endpoint para listagem de todos os cursos cadastrados.

#### Exemplo Retorno:

```
[{
    "id": 1,
    "titulo": "Curso",
    "capa": "https/www.sou-img.com",
    "nomeProfessor": "Nome do Professor",
    "descricao": "Alguma descrição"
  },
  {
    "id": 2,
    "titulo": "Curso Dois",
    "capa": "https/www.sou-img.com",
    "nomeProfessor": "Nome do Professor",
    "descricao": "Alguma descrição"
  }
]
```
	
Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NotFound
	
	
### 2. GET /api/Curso/{id}

Endpoint para obter um único Curso pelo seu ID

#### Exemplo Retorno:

```
{
  "id": 1,
  "titulo": "Curso",
  "capa": "https/www.sou-img.com",
  "nomeProfessor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```
	
Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND
	
	
### 3. GET /api/Curso/AulasDoCurso/{id}

Endpoint para listar todas as aulas referente ao ID de um curso

#### Exemplo Body:

```
[
  {
    "titulo": "Aula Um",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  },
  {
    "titulo": "Aula Dois",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  }
]
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 4. POST /api/Curso

Endpoint para cadastrar um novo Curso

#### Exemplo Body:

```
{
  "titulo": "Curso",
  "capa": "https/www.sou-img.com",
  "nomeProfessor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```

Códigos Http de Retorno Possíveis:

- 201 - CREATED
- 400 - BAD REQUEST ()

### 5. POST /api/Curso/AulaDoCurso?titulo=Titulo-Curso

Endpoint para cadastrar aulas de um curso

#### Exemplo Body:

```
[
   {
    "titulo": "Aula Um",
    "link": "https/www.sou-um-link.com-01",
	  "descricao": "descricao"
  },
{
    "titulo": "Aula Dois",
    "link": "https/www.sou-um-link.com-02",
    "descricao": "descricao"
  }
]
```

Códigos Http de Retorno Possíveis:

- 201 - CREATED
- 400 - BAD REQUEST ()

### 6. PUT /api/Curso/{id}

Endpoint para atualizar um Curso

#### Exemplo Body:

```
{
  "titulo": "Curso",
  "capa": "https/www.sou-img.com.uuu",
  "nomeProfessor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 7. PUT /api/Curso/AulaDoCurso?titulo=Primeiro-Curso&tituloAula=Primeira-Aula

Endpoint para atualizar uma Aula

#### Exemplo Body:

```
{
 {
    "titulo": "Update Aula",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  }
}
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 8. DELETE /api/Curso/{id}

Endpoint para excluir um Curso e as aulas referentes

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT

### 9. DELETE /api/Curso/AulaDoCurso?id=Value&tituloAula=Primeira-Aula

Endpoint para excluir uma aula

⚠️ 
  
ATENÇÃO: A cada espaço do titulo da Aula, deve ser substituido por (-).
  
Primeira Aula = Primeira-Aula

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

```

## 🦸 By Scarlet gabriella

```
