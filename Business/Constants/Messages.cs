using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "The car is successfully added";
        public static string CarDeleted = "The car is successfully deleted";
        public static string CarUpdated = "The car is successfully updated";
        public static string CarUpdateInvalid = "The car cannot be updated";
        public static string CarInvalid = "The car could not be added";
        public static string MaintenanceTime = "System is under maintenance";
        public static string CarListed = "Cars are listed";
        public static string CarRented = "The car has been rented";
        public static string CarRentedInvalid = "The car has been rented already";
        public static string ImageLimitExceeded = "The car cannot have more than five images";
        public static string AuthorizationDenied = "You are not authorized";
        public static string UserRegistered = "User successfuly registered";
        public static string UserNotFound = "User is not found";
        public static string PasswordError = "Password is wrong";
        public static string SuccessfulLogin = "Succesful login";
        public static string UserAlreadyExists = "The user already exists";
        public static string AccessTokenCreated = "Access token successfully created";
        public static string PaymentSuccess = "Payment successfully fulfilled";
        public static string CarOwnerError = "Invalid car owner";
        public static string CvcError = "Invalid cvc";
        public static string ExpirationDateError = "Invalid expiration date";
        public static string CardNumberError = "Invalid card number";
    }
}
