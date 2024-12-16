using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Categories.Commands.DeleteCategory;

internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IGenericRepository<Category> _categoryRepository;

    public DeleteCategoryCommandHandler(
        IGenericRepository<Category> categoryRepository) =>
        _categoryRepository = categoryRepository;
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {

        };

        //await _categoryRepository.DeleteAsync(category);
    }
}








