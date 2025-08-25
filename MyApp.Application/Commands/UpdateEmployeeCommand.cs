using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public record UpdateEployeeCommand(Guid EmployeeId, EmployeeEntity Employee) : IRequest<EmployeeEntity>;
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeeAsync(request.EmployeeId, request.Employee);
        }
    }
}
