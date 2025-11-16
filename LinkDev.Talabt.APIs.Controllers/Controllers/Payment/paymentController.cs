using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.APIs.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabt.APIs.Controllers.Controllers.Payment
{
    public class paymentController:BaseApiController
    {

        [HttpPost("{serviceRequestId}")]
        [Authorize]
        public async Task<IActionResult> CreatePaymentIntent(int serviceRequestId)
        {

            //var result = await PaymentService.CreateOrUpdatePaymentIntent(serviceRequestId);

            return Ok();


        }

        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            //await PaymentService.UpdatePaymentStatus(json, HttpContext.Request.Headers["Stripe-Signature"]);

            return Ok();
        }
    }
}
