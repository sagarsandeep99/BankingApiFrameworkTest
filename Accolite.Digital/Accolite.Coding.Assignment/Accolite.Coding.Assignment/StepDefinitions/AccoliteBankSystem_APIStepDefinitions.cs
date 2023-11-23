using Accolite.Coding.Assignment.Model;
using Accolite.Coding.Assignment.Model.Request;
using Accolite.Coding.Assignment.Model.Response;
using Accolite.Coding.Assignment.Utils;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Configuration;

namespace Accolite.Coding.Assignment.StepDefinitions
{
    [Binding]
    public class AccoliteBankSystem_APIStepDefinitions
    {

        private CreateAccountRequest _createAccountRequest;
        private DepositAmountRequest _depositAmountRequest;
        private WithdrawAmountRequest _withdrawAmountRequest;
        private RestResponse _response;
        private HttpStatusCode _statusCode;
        string _accountNumber;
        private Helper _helper;

        public AccoliteBankSystem_APIStepDefinitions
            (CreateAccountRequest createAccountRequest,DepositAmountRequest depositAmountRequest, WithdrawAmountRequest withdrawAmountRequest) 

        {
            _createAccountRequest = createAccountRequest;
            _depositAmountRequest = depositAmountRequest;
            _withdrawAmountRequest = withdrawAmountRequest;

        }

        #region Given

        [Given(@"Account Holder name is (.*)")]
        public void GivenAccountHolderNameIs(string AccountName)
        {
            _createAccountRequest.AccountName = AccountName;
        }

        [Given(@"Deposit money for the account is (.*)")]
        public void GivenDepositMoneyForTheAccountIs(long Amount)
        {
            _createAccountRequest.Amount = Amount;
        }

        [Given(@"Bank is located in the address (.*)")]
        public void GivenBankIsLocatedInTheAddress(string Address)
        {
            _createAccountRequest.Address = Address;
        }

        [Given(@"Account number is (.*)")]
        public void GivenAccountNumberIs(string AccountNo)
        {
            _depositAmountRequest.AccountNumber = AccountNo;
            _withdrawAmountRequest.AccountNumber = AccountNo;
            _accountNumber= AccountNo;
        }

        [Given(@"Withdrawal money from the account is (.*)")]
        public void GivenWithdrawalMoneyFromTheAccountIs(long Amount)
        {
            _withdrawAmountRequest.Amount = Amount;
        }

        [Given(@"the base url used is (.*)")]
        public void WhenTheBaseUrlUsedIs(string baseUrl)
        {
            _helper = new Helper(baseUrl);
        }
        #endregion

        #region When




        [When(@"POST endpoint is triggered to create a new bank account with the above details")]
        public async Task WhenPOSTEndpointIsTriggeredToCreateANewBankAccountWithTheAboveDetails()
        {
            _response = await _helper.CreateAccount<CreateAccountRequest>(_createAccountRequest);
        }

        [When(@"DELETE endpoint is triggered to delete an existing bank account with the above details")]
        public async Task WhenDELETEEndpointIsTriggeredToDeleteAnExistingBankAccountWithTheAboveDetails()
        {
            _response = await _helper.DeleteAccount(_accountNumber);
        }

        [When(@"PUT endpoint is triggered to deposit amount in a bank account with the above details")]
        public async void WhenPUTEndpointIsTriggeredToDepositAmountInABankAccountWithTheAboveDetails()
        {
            _response = await _helper.DepositeAmount<DepositAmountRequest>(_depositAmountRequest);
        }

        [When(@"PUT endpoint is triggered to withdraw amount from bank account with the above details")]
        public async void WhenPUTEndpointIsTriggeredToWithdrawAmountFromBankAccountWithTheAboveDetails()
        {
            _response = await _helper.WithdrawAmount<WithdrawAmountRequest>(_withdrawAmountRequest);
        }

        #endregion

        #region Then

        [Then(@"Verify the response code is 200")]
        public void ThenVerifyTheResponseCodeIs200()
        {
            _statusCode = _response.StatusCode;
            var code = (int)_statusCode;
            Assert.AreEqual(HttpStatusCode.OK, code );
        }

        [Then(@"Verify the success message (.*)")]
        public void ThenVerifyTheSuccessMessage(string Message)
        {
           var content= _helper.GetContent<GenericResponse>(_response);
           Assert.AreEqual(Message, content.Message);
        }

        [Then(@"Verify the response body with the correct account details has been created")]
        public void ThenVerifyTheResponseBodyWithTheCorrectAccountDetailsHasBeenCreated()
        {
            var content = _helper.GetContent<CreateAccountResponse>(_response);
            Assert.AreEqual(_createAccountRequest.AccountName, content.AccountData);
            Assert.AreEqual(_createAccountRequest.Amount, content.AccountData.AmountBalance);
        }

        [Then(@"Verify the response body with the correct account details has been deleted")]
        public void ThenVerifyTheResponseBodyWithTheCorrectAccountDetailsHasBeenDeleted()
        {
            var content = _helper.GetContent<GenericResponse>(_response);
            Assert.AreEqual(_accountNumber, content.AccountData.AccountNo);
        }

        [Then(@"Verify the response body with the correct account details and new balance")]
        public void ThenVerifyTheResponseBodyWithTheCorrectAccountDetailsAndNewBalance()
        {
            var content = _helper.GetContent<GenericResponse>(_response);
            Assert.AreEqual(_depositAmountRequest.Amount, content.AccountData.AmountBalance);
            Assert.AreEqual(_withdrawAmountRequest.Amount, content.AccountData.AmountBalance);
        }


        #endregion

    }
}
