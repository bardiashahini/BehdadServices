using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsBehdadWebServices
{
    public static class Messages
    {
        #region [ Account Service ]
        public const string UnableToAuthenticateExceptionMessage = "عملیات شناسایی کاربر با مشکل مواجه شد";
        public const string InvalidCredentialExceptionMesssage = "شناسه کاربری یا رمز عبور نادرست است";
        public const string InvalidIdentifierTypeExceptionMessage = "نوع شناسه واریز معتبر نیست";
        public const string InvalidIdentifierControlTypeExceptionMessage = "نوع شناسه واریز معتبر نیست";
        #endregion

        #region [ Allotment Service ]
        public const string InvalidDateExceptionMessage = "تاریخ معتبر نیست";
        public const string InvalidAllotmentItemInfoExceptionMessage = "قایده تسهیم معتبر نیست";
        public const string InvalidAllotmentCodeExceptionMessage = "کد تسهیم معتبر نیست";
        public const string InvalidAllotmentAmountTypeExceptionMessage = "نوع مبلغ تسهیم معتبر نیست";
        public const string AllotmentAmountIsMoreThanTransactionAmountExceptionMessage = "مجموع مبالغ تراکنشهای تسهیم از مبلغ تراکنش پرداخت بیشتر است";
        public const string InvalidTransactionIdExceptionMessage = "تراکنش نادرست است یا قابل تسهیم نیست";
        public const string InvalidAllotmentExceptionMessage = "مبلغ قابل تسهیم نیست";
        public const string UnableToAllotExceptionMessage = "عملیات تسهیم با خطا مواجه شد";
        public const string TransactionAlreadyAllotedExceptionMessage = "این تراکنش قبلاً تسهیم شده است";
        public const string InvalidTransactionForAllotmentExceptionMessage = "اين تراكنش قابهل تسهیم نيست";
        public const string PageSizeIsTooMuchExceptionMessage = "تعداد ركوردهای درخواست شده درهرصفحه بیشتر از حد مجاز است";
        #endregion

        #region [ Identifier Service ]
        public const string IdentifierIsExistExceptionMessage = "شناسه واریز تکراری است";
        public const string InvalidAccountNumberExceptionMessage = "شناسه حساب معتبر نیست";
        public const string InvalidIdentifierCodeExceptionMessage = "شناسه واریز معتبر نیست";
        public const string InvalidAmountExceptionMessage = "مبلغ معتبر نیست";
        public const string IdentifierNotFoundExceptionMessage = "شناسه واریز یافت نشد";
        public const string IdentifierIsNotEffectiveExceptionMessage = "شناسه واریز فعال نیست";
        public const string VerhoeffExceptionMessage = "ارقام کنترلی شناسه واریز معتبر نیست";
        public const string UnableToGenerateIdentifierExceptionMessage = "شناسه واریز جدید قابل ایجاد نیست";

        #endregion

        #region [ General Messages ]
        public const string EmptyDataSource = "رکوردی برای نمایش وجود ندارد";
        #endregion


    }
}
