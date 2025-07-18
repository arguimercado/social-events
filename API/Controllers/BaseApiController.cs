using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

 

 public class BaseApiController : ControllerBase
 {
     protected readonly IMediator Mediator; 

     protected BaseApiController(IMediator mediator)
     {
         Mediator = mediator;
     }
 }
