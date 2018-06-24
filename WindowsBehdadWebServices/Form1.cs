using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsBehdadWebServices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region [ Fields ]

        AccountService.AccountServiceClient accountClient = new AccountService.AccountServiceClient();
        AllotmentService.AllotmentServiceClient allotmentClient = new AllotmentService.AllotmentServiceClient();

        #endregion

        #region [ Properties ]
        #endregion

        #region [ Public Methods ]
        #endregion

        #region [ Private Methods ]
        private AccountService.credential GetAccountCredential()
        {
            AccountService.credential accountCredential = new AccountService.credential();
            accountCredential.username = System.Configuration.ConfigurationManager.AppSettings.Get("UserName");
            accountCredential.password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");


            return accountCredential;

        }

        //private AllotmentService.allotmentAmountType? GetAmountType(string amountType)
        //{
        //    if (String.IsNullOrEmpty(amountType))
        //        return null;

        //    if (String.IsNullOrWhiteSpace(amountType))
        //        return null;

        //    AllotmentService.allotmentAmountType amountTypeEnum;
        //    if (Enum.TryParse<AllotmentService.allotmentAmountType>(amountType.ToUpper(), out amountTypeEnum))
        //    {
        //        return amountTypeEnum;
        //    }

        //    return null;
        //}

        
        private AllotmentService.credential GetAllotmentCredential()
        {
            AllotmentService.credential allotmentCredential = new AllotmentService.credential();

            allotmentCredential.username = System.Configuration.ConfigurationManager.AppSettings.Get("UserName");
            allotmentCredential.password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");

            return allotmentCredential;
        }
        #endregion

        #region [ Events ] 

        #region [ Account Service ]
        private void btnClearAccountControlType_Click(object sender, EventArgs e)
        {
            try
            {
                AccountService.credential accountcredential = null;
                accountcredential = GetAccountCredential();

                if (accountcredential != null)
                {
                    accountClient.clearAccountControlType(accountcredential, txtAccountNumber.Text, txtIdentifierType.Text);
                }

            }
            catch (FaultException<AccountService.UnableToAuthenticateException> unableAutExcp)
            {
                MessageBox.Show(Messages.UnableToAuthenticateExceptionMessage + " " + unableAutExcp.Message);
            }

            catch (FaultException<AccountService.InvalidCredentialException> invCredExc)
            {
                MessageBox.Show(Messages.InvalidCredentialExceptionMesssage + " " + invCredExc.Message);
            }

            catch (FaultException<AccountService.InvalidIdentifierTypeException> invIdentTypexc)
            {
                MessageBox.Show(Messages.InvalidIdentifierTypeExceptionMessage + " " + invIdentTypexc.Message);
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnGetAccountNumber_Click(object sender, EventArgs e)
        {
            try
            {
                AccountService.credential accountcredential = null;
                accountcredential = GetAccountCredential();
                string[] accountNumbersList = new string[] { };
                if (accountcredential != null)
                {
                    accountNumbersList = accountClient.getAccountNumbers(accountcredential);
                }

                lstAccountNumbers.DataSource = accountNumbersList;

            }
            catch (FaultException<AccountService.UnableToAuthenticateException> unableAutExcp)
            {
                MessageBox.Show(Messages.UnableToAuthenticateExceptionMessage + " " + unableAutExcp.Message);
            }

            catch (FaultException<AccountService.InvalidCredentialException> invCredExc)
            {
                MessageBox.Show(Messages.InvalidCredentialExceptionMesssage + " " + invCredExc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
        private void btnGetAccountControlType_Click(object sender, EventArgs e)
        {
            try
            {
                AccountService.credential accountcredential = null;
                accountcredential = GetAccountCredential();
                string identifierType = string.Empty;

                if (accountcredential != null)
                {
                    identifierType = accountClient.getAccountControlType(accountcredential, txtGetAccountNumberControlType.Text, txtGetIdentifierType.Text);
                }

                txtReturnIdentifierType.Text = identifierType;

            }
            catch (FaultException<AccountService.UnableToAuthenticateException> unableAutExcp)
            {
                MessageBox.Show(Messages.UnableToAuthenticateExceptionMessage + " " + unableAutExcp.Message);
            }

            catch (FaultException<AccountService.InvalidCredentialException> invCredExc)
            {
                MessageBox.Show(Messages.InvalidCredentialExceptionMesssage + " " + invCredExc.Message);
            }
            catch (FaultException<AccountService.InvalidIdentifierTypeException> invIdentTypexc)
            {
                MessageBox.Show(Messages.InvalidIdentifierTypeExceptionMessage + " " + invIdentTypexc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
        private void btnSetAccountControlType_Click(object sender, EventArgs e)
        {
            try
            {
                AccountService.credential accountcredential = null;
                accountcredential = GetAccountCredential();

                AccountService.accountControlCreateModel createModel = new AccountService.accountControlCreateModel()
                {
                    accountNumber = txtSetAccounNumberControlType.Text,
                    controlType = txtSetControlType.Text,
                    identifierType = txtSetIdentifierControlType.Text,
                    toDate = txtSetToDateControlType.Text
                };


                if (accountcredential != null)
                {
                    accountClient.setAccountControlType(accountcredential, createModel);
                }
            }
            catch (FaultException<AccountService.UnableToAuthenticateException> unableAutExcp)
            {
                MessageBox.Show(Messages.UnableToAuthenticateExceptionMessage + " " + unableAutExcp.Message);
            }

            catch (FaultException<AccountService.InvalidCredentialException> invCredExc)
            {
                MessageBox.Show(Messages.InvalidCredentialExceptionMesssage + " " + invCredExc.Message);
            }
            catch (FaultException<AccountService.InvalidIdentifierControlTypeException> invIndtfCntrltypExc)
            {
                MessageBox.Show(Messages.InvalidIdentifierControlTypeExceptionMessage + " " + invIndtfCntrltypExc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnGetPendingTransactions_Click(object sender, EventArgs e)
        {
            try

            {
                AccountService.credential accountcredential = null;
                accountcredential = GetAccountCredential();

                bool recordCountSpecified = false;

                if (txtGetPendingRecordCount.Text != string.Empty)
                {
                    recordCountSpecified = true;
                }
                else
                {
                    recordCountSpecified = false;
                }

                bool pageNumberSpecified = false;
                if (txtGetPendingPageNumber.Text != string.Empty)
                {
                    pageNumberSpecified = true;
                }
                else
                {
                    pageNumberSpecified = false;
                }

                int convertPageNumber = 0;
                bool convertPageNumberResult = false;

                int convertRecorcount = 0;
                bool ConvertRecordcountResult = false;

                convertPageNumberResult = Int32.TryParse(txtGetPendingPageNumber.Text, out convertPageNumber);
                ConvertRecordcountResult = Int32.TryParse(txtGetPendingRecordCount.Text, out convertRecorcount);

                if (convertPageNumberResult && convertPageNumberResult)
                {
                    AccountService.paging objPaging = new AccountService.paging()
                    {

                        pageNumber = convertPageNumber,
                        recordCount = convertRecorcount,
                        pageNumberSpecified = pageNumberSpecified,
                        recordCountSpecified = recordCountSpecified

                    };




                    if (accountcredential != null)
                    {
                        AccountService.pagedData pagedData = null;
                        pagedData = accountClient.getPendingTransactions(accountcredential, txtGetPendingAccountNumber.Text, objPaging);
                        if (pagedData != null)
                        {
                            grdViewPendingTransactions.DataSource = pagedData;
                        }
                        else
                        {
                            MessageBox.Show(Messages.EmptyDataSource);
                        }
                    }
                }
            }

            catch (FaultException<AccountService.UnableToAuthenticateException> unableAutExcp)
            {
                MessageBox.Show(Messages.UnableToAuthenticateExceptionMessage + " " + unableAutExcp.Message);
            }

            catch (FaultException<AccountService.InvalidCredentialException> invCredExc)
            {
                MessageBox.Show(Messages.InvalidCredentialExceptionMesssage + " " + invCredExc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnGetBankTransactionDetail_Click(object sender, EventArgs e)
        {
            try
            {
                AccountService.credential accountcredential = null;
                accountcredential = GetAccountCredential();

                bool recordCountSpecified = false;

                if (txtGetBankTransDetailRecordCount.Text != string.Empty)
                {
                    recordCountSpecified = true;
                }
                else
                {
                    recordCountSpecified = false;
                }

                bool pageNumberSpecified = false;
                if (txtGetBankTransDetailPageNumber.Text != string.Empty)
                {
                    pageNumberSpecified = true;
                }
                else
                {
                    pageNumberSpecified = false;
                }

                int convertPageNumber = 0;
                bool convertPageNumberResult = false;

                int convertRecorcount = 0;
                bool ConvertRecordcountResult = false;

                convertPageNumberResult = Int32.TryParse(txtGetBankTransDetailPageNumber.Text, out convertPageNumber);
                ConvertRecordcountResult = Int32.TryParse(txtGetBankTransDetailRecordCount.Text, out convertRecorcount);

                if (convertPageNumberResult && convertPageNumberResult)
                {
                    AccountService.paging objPaging = new AccountService.paging()
                    {

                        pageNumber = convertPageNumber,
                        recordCount = convertRecorcount,
                        pageNumberSpecified = pageNumberSpecified,
                        recordCountSpecified = recordCountSpecified

                    };

                    AccountService.accountTransactionFilter transactionFilter = new AccountService.accountTransactionFilter()
                    {
                        accountNumber = txtGetBankTransDetailAccountNumber.Text,
                        fromDateTime = txtGetBankTransDetailFrom.Text,
                        toDateTime = txtGetBankTransDetailTo.Text,
                        paymentIdentifier = txtGetBankTransDetailPaymentIdentifier.Text
                    };
                    if (accountcredential != null)
                    {
                        AccountService.pagedData pagedData = null;
                        pagedData = accountClient.getBankTransactionsDetails(accountcredential, transactionFilter, objPaging);

                        if (pagedData != null)
                        {
                            grdViewBankTransDetail.DataSource = pagedData;
                        }
                        else
                        {
                            MessageBox.Show(Messages.EmptyDataSource);
                        }

                    }
                }


            }
            //TODO: Complete Exception List
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region [ Allotment Service ]
        private void btnAddAllotmentInfo_Click(object sender, EventArgs e)
        {
            long result = 0;
            try
            {
                AllotmentService.credential allotmentCredential = null;
                allotmentCredential = GetAllotmentCredential();


                bool isAmountSpecified = false;
                if (txtAmount.Text != string.Empty)
                {
                    isAmountSpecified = true;
                }
                else
                {
                    isAmountSpecified = false;
                }

                AllotmentService.allotmentAmountType amountType = AllotmentService.allotmentAmountType.MONETARY;                
                bool amountTypeSpecified = false;
                if (txtAmountType.Text != string.Empty)
                {
                    if (txtAmountType.Text == AllotmentService.allotmentAmountType.MONETARY.ToString())
                    {
                        amountType = (AllotmentService.allotmentAmountType)0;
                        amountTypeSpecified = true;
                    }
                    if (txtAmountType.Text == AllotmentService.allotmentAmountType.PERCENT.ToString())
                    {
                        amountType = (AllotmentService.allotmentAmountType)1;
                        amountTypeSpecified = true;
                    }

                }
                
                if (allotmentCredential != null)
                {
                    result = allotmentClient.addAllotmentInfo(allotmentCredential, new AllotmentService.allotmentInfoDetail()
                    {
                        allotmentCode = txtAllotmentCode.Text,
                        amount = Decimal.Parse(txtAmount.Text),
                        amountSpecified = isAmountSpecified,
                        amountTypeSpecified = amountTypeSpecified,
                        amountType = amountType,
                        description = txtDesc.Text,
                        destAccountNumber = txtDestAccountNo.Text,
                        sourceAccountNumber = txtSourceAccountNo.Text,
                        incomeIndexCode = txtIncomeIndexCode.Text,
                        incomeSubsidiaryCode = txtSubsidiaryCode.Text,
                        organCustomCode = txtOrganCustomCode.Text,
                        startDate = txtStartDate.Text,
                        endDate = txtEndDate.Text
                    });

                    txtRecordId.Text = result.ToString();
                }
            }
            catch (FaultException<AllotmentService.InvalidDateException> invDateExc)
            {
                MessageBox.Show(Messages.InvalidDateExceptionMessage + " " + invDateExc.Message);
            }
            catch (FaultException<AllotmentService.InvalidAllotmentItemInfoException> invAllotmentInfoExc)
            {
                MessageBox.Show(Messages.InvalidAllotmentItemInfoExceptionMessage + " " + invAllotmentInfoExc.Message);
            }
            catch (FaultException<AllotmentService.UnableToAuthenticateException> unableAuthExc)
            {
                MessageBox.Show(Messages.UnableToAuthenticateExceptionMessage + " " + unableAuthExc.Message);
            }
            catch (FaultException<AllotmentService.InvalidCredentialException> invCredentialExc)
            {
                MessageBox.Show(Messages.InvalidCredentialExceptionMesssage + " " + invCredentialExc.Message);
            }
            catch (FaultException<AllotmentService.InvalidAllotmentCodeException> invAllotmentCodeExc)
            {
                MessageBox.Show(Messages.InvalidAllotmentCodeExceptionMessage + " " + invAllotmentCodeExc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        #endregion

        #region [ Identifier Service ]

        #endregion

        #endregion


    }


}
