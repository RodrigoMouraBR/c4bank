using FinancialFlow.API.Controllers;
using FinancialFlow.Application.Interfaces;
using FinancialFlow.Application.Models;
using FinancialFlow.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialFlow.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/financial-transaction/")]
    public class FinancialTransactionController : MainController
    {
        private readonly IFinancialTransactionAppService _appService;
        public FinancialTransactionController(INotifier notifier, IFinancialTransactionAppService appService) : base(notifier)
        {
            _appService = appService;
        }

        /// <summary>
        ///  - Adicionar uma transação financeira.
        /// </summary>
        /// <param name="CustomerId">Simula o ID do cliente</param>        
        /// <param name="Amount">Valor a ser lançado no sistema</param>
        /// <param name="Description">Descrição do lançamento</param>
        /// <param name="TransactionType">Tipo de transação: (PIX =0, Credit = 1, Debit = 2, Boleto = 3)</param>
        /// <returns>Retorno boleano (true/false)</returns>

        [HttpPost("add-financial")]
        public async Task<IActionResult> AddFinancialTransaction([FromBody] FinancialTransactionModel financialTransactionModel)
        {
            var result = await _appService.AddFinancialTransactionQueue(financialTransactionModel);
            return CustomResponse(result);
        }

        /// <summary>
        /// Retorna a consulta dos lançamentos consolidados/mês
        /// </summary>
        /// <returns></returns>

        [HttpGet("MonthlyConsolidated")]
        public async Task<IActionResult> GetMonthlyConsolidatedReportAsync()
        {
            var result = await _appService.GetMonthlyConsolidatedReportAsync();
            return CustomResponse(result);
        }
        /// <summary>
        /// Retorna a consulta dos lançamentos consolidados/dia
        /// </summary>
        /// <returns></returns>
        [HttpGet("DailyConsolidatedReport")]
        public async Task<IActionResult> GetDailyConsolidatedReportAsync()
        {
            var result = await _appService.GetDailyConsolidatedReportAsync();
            return CustomResponse(result);
        }

        /// <summary>
        /// Retorna a consulta dos lançamentos consolidados/ano
        /// </summary>
        /// <returns></returns>

        [HttpGet("YearlyConsolidatedReport")]
        public async Task<IActionResult> GetYearlyConsolidatedReportAsync()
        {
            var result = await _appService.GetYearlyConsolidatedReportAsync();
            return CustomResponse(result);
        }
    }
}
