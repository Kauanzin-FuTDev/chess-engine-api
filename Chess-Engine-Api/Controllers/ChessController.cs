
using Chess_Application.UseCases.Commands.MoveUseCases;
using Chess_Application.UseCases.StartGame;
using Chess_Application.UseCases.ViewGame;
using Chess_Domain.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Chess_Engine_Api.Controllers;



[ApiController]
[Route("api/chess/[controller]")]
public class ChessController : ControllerBase
{
    private readonly ILogger<ChessController> _logger;
    private readonly StartGameHandler _startGameHandler;
    private readonly ViewGameHandler _viewGameHandler;
    private readonly MoveHandler _moveHandler;

    public ChessController(ILogger<ChessController> logger, StartGameHandler StartGameHandler, ViewGameHandler ViewGameHandler,
        MoveHandler MoveHandler)
    {
        _logger = logger;
        _startGameHandler = StartGameHandler;
        _viewGameHandler = ViewGameHandler;
        _moveHandler = MoveHandler;
    }
    
    
    [HttpPost( "Start")]
    public async Task<IActionResult> StartGame()
    {
        var command = new StartGameCommand
        {
            PlayerWhiteId = "player1",
            PlayerBlackId = "player2"
        };
        try
        {
            var result = await _startGameHandler.Handle(command);
            _logger.LogInformation("Starting a new chess game between {PlayerWhiteId} and {PlayerBlackId}",
                command.PlayerWhiteId, command.PlayerBlackId);
            return Ok(result);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging the start of a new chess game.");
            return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("Move/{id:guid}")]
    public async Task<IActionResult> Move([FromBody] MoveCommand command)
    {
        try
        {
            var result = await _moveHandler.Handle(command);
            _logger.LogInformation("Making a move in game {GameId} from {From} to {To}", command.GameId, command.From, command.To);
            return Ok(result);
        }
        catch (ApplicationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging a move in a chess game.");
            return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    

    [HttpGet("ViewGame/{id:guid}")]
    public async Task<IActionResult> ViewGame(Guid id)
    {
        var command = new ViewGameCommand
        {
            GameId = id
        };
        
        try
        {
            var result = await _viewGameHandler.Handle(command);
            _logger.LogInformation("Viewing game {GameId}", command.GameId);
            return Ok(result);
        }
        catch (ApplicationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging the view of a chess game.");
            
            return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
        
    }
}