using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Categories.Commands.CreateCategory;

internal class CreateCategoryCommandHandler(
    IGenericRepository<Category> categoryRepository) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {

        };

        await categoryRepository.CreateAsync(category);
    }
}








