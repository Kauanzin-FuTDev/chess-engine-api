# ♟️ Chess Engine API

**Chess Engine API** é um backend responsável por processar, validar e aplicar todas as regras do xadrez no lado do servidor.  
O frontend atua apenas como **consumidor de comandos** e **leitor do estado do jogo**.

O projeto segue **Clean Architecture**, **Domain-Driven Design (DDD)** e foi pensado para ser escalável, testável e reutilizável.

Ideal para:
- jogos multiplayer de xadrez
- integração com bots / IA
- aplicações web e mobile
- ferramentas de análise de partidas

---

## 🧠 Arquitetura

Estrutura baseada em responsabilidades claras:

🧠 Arquitetura do Projeto

📦 Camadas principais
```
Chess-Engine-Api         ← API (controllers, rotas)
Chess-Application        ← Casos de uso / Application logic
Chess-Domain             ← Regras de xadrez, modelo do jogo
Chess-Infrastructure     ← Persistência em memória / futuros DB
Chess-Ioc                ← Dependências (DI)
```

📌 **Toda regra de xadrez vive no Domain**  
📌 **Application coordena o fluxo**  
📌 **API apenas expõe endpoints**

## 🚀 Versionamento da API

A API utiliza **versionamento por rota**, permitindo evolução sem quebrar consumidores existentes.

Padrão:
```
/api/v1/...
```
Exemplo:
```
GET /api/v1/games/{gameId}
POST /api/v1/games
```

Isso permite evoluções sem quebrar quem já consome a API.

## 📡 Como Consumir a API

### ▶️ Iniciar um novo jogo

```
POST /api/v1/games/start
```

📦 Retorna:

```json
{
  "success": true,
  "gameId": "guid-gerado"
}
```

### 🔍 Visualizar estado do jogo

```
GET /api/v1/games/{gameId}
```

📦 Retorno:
```json
{
  "gameId": "...",
  "currentTurn": "White",
  "pieceCount": 32,
  "isGameOver": false,
  "pieces": [
    {
      "type": "Pawn",
      "color": "White",
      "position": "e2"
    }
  ...
  ]
}
```

### 🏃‍♂️ Mover uma peça
```
POST /api/v1/games/{gameId}/moves
```

📤 Body:
```json
{
  "from":"e2",
  "to":"e4"
}
```

📦 Sucesso:
```json
{
  "success": true,
  "gameId": "...",
  "message": "Move executed"
}
```

### 📘 Representação do Tabuleiro

A API retorna as peças no formato:
```
position: "e4"
type: "Pawn"
color: "White"
```

Exemplo de representação visual:
```
8 | r n b q k b n r
7 | p p p p p p p p
6 | . . . . . . . .
5 | . . . . . . . .
4 | . . . . . . . .
3 | . . . . . . . .
2 | P P P P P P P P
1 | R N B Q K B N R
    a b c d e f g h
```
📜 Licença

Este projeto está sob MIT License
Veja o arquivo LICENSE para detalhes.
