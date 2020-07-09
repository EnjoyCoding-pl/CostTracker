using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using D = CostTracker.Domain.Models;

namespace CostTracker.Core.Commands.Cost.Create
{
    public class CreateCostCommandHandler : IRequestHandler<CreateCostCommand>
    {
        private readonly IApplicationDBContext _context;
        private readonly IFileManager _fileManager;

        public CreateCostCommandHandler(IApplicationDBContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        public async Task<Unit> Handle(CreateCostCommand request, CancellationToken cancellationToken)
        {
            var cost = D.Cost.Create(request.Name, request.Amount, request.VatRate);
            var part = await _context.Parts.FirstOrDefaultAsync(x => x.ExternalId == request.PartExternalId);

            part.AddCost(cost);

            var url = await _fileManager.UploadAsync(request.File, request.FileName);

            cost.SetInvoiceUrl(url);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}