<h1 align="center">
    API Dindin.Web
  
## 💻 Sobre o projeto

CRUD de Cursos e aulas.
	
Dindin.Dominio = Regra de Negócio / Repositório

Dindin.Web = Api REST

## ▶️ Executando o projeto
 
Solução: backend.sln	
	
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
    "nome_professor": "Nome do Professor",
    "descricao": "Alguma descrição",
    "aulas": []	
  },
  {
    "id": 2,
    "titulo": "Curso Dois",
    "capa": "https/www.sou-img.com",
    "nome_professor": "Nome do Professor",
    "descricao": "Alguma descrição",
    "aulas": []
  }
]
```
	
Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NotFound
	
	
### 2. GET /api/Curso/{id}

Endpoint para obter um único curso pelo seu ID

#### Exemplo Retorno:

```
{
  "id": 1,
  "titulo": "Curso",
  "capa": "https/www.sou-img.com",
  "nome_professor": "Nome do Professor",
  "descricao": "Alguma descrição",
  "aulas": []
}
```
	
Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND
	
	
### 3. GET /api/Curso/AulasDoCurso/{id}

Endpoint para listar todas as aulas referente ao ID de um curso

#### Exemplo Retorno:

```
[
  {
    "titulo": "Aula Um",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao",
    "cursoID": 20
  },
  {
    "titulo": "Aula Dois",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao",
    "cursoID": 20
  }
]
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 4. POST /api/Curso

Endpoint para cadastrar um novo curso e aulas

#### Exemplo Body:

```
{
  "titulo": "Curso",
  "capa": "https/www.sou-img.com",
  "nome_professor": "Nome do Professor",
  "descricao": "Alguma descrição",
  "Aulas": [
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
}
```

Códigos Http de Retorno Possíveis:

- 201 - CREATED
- 400 - BAD REQUEST ()

### 6. PUT /api/Curso/{id}

Endpoint para atualizar um curso

#### Exemplo Body:

```
{
  "titulo": "Curso",
  "capa": "https/www.sou-img.com.uuu",
  "nome_professor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 7. PUT /api/Curso/AulaDoCurso?id=Value&tituloAula=Primeira-Aula

Endpoint para atualizar uma aula

#### Exemplo Body:

```
 {
    "titulo": "Update Aula",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  }
	
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 8. DELETE /api/Curso/{id}

Endpoint para excluir um curso e as aulas referentes

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT

### 9. DELETE /api/Curso/AulaDoCurso?id=Value&tituloAula=Primeira-Aula

Endpoint para excluir uma aula

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

```

## 🦸 By Scarlet Gabriella

```
