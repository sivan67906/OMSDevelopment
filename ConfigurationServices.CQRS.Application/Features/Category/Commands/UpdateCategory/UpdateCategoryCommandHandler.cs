using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Categories.Commands.UpdateCategory;

internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IGenericRepository<Category> _categoryRepository;

    public UpdateCategoryCommandHandler(
        IGenericRepository<Category> categoryRepository) =>
        _categoryRepository = categoryRepository;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
        };

        await _categoryRepository.UpdateAsync(category);
    }
}








