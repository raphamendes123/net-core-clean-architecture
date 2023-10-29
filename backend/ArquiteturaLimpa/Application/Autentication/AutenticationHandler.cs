using Application.Common.Exceptions;
using Application.Common.Validator;
using AutoMapper;
using Domain.Model;
using Domain.Model.Autentication; 
using MediatR;
using Service.Autentication.Interface; 

namespace Application.Autentication;

public class AutenticationHandler : IRequestHandler<AutenticationCommand, AutenticationResponse>
{
    private readonly IMapper mapper;
    private readonly IAutenticationService autenticationService;

    public AutenticationHandler(IAutenticationService autenticationService, IMapper mapper)
    {
        this.autenticationService = autenticationService;
        this.mapper = mapper;
    }

    public async Task<AutenticationResponse> Handle(AutenticationCommand request, CancellationToken cancellationToken)
    {
        var validate = new AutenticationUseCase().Validate(request);

        if (!validate.IsValid)
            throw new ValidationException(validate.Errors.ToValidationFailure());

        var userAutentication = mapper.Map<AutenticationModel>(request);
        
        return await autenticationService.Authenticate(userAutentication);
    }
}
