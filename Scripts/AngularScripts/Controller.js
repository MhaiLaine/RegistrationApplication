app.controller("RegistrationApplicationController", function ($scope, RegistrationApplicationService) {

    $scope.emailPattern = /^[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    var userCredentials = [];

    //submit Button
    $scope.submitRegistration = function () {
        var registrationData = {
            FirstName: $scope.firstName,
            MiddleName: $scope.middleName,
            LastName: $scope.lastName,
            Email: $scope.email,
            Address: $scope.address,
            PhoneNumber: $scope.phoneNumber,
            Username: $scope.firstName + "." + $scope.lastName,
            Password: $scope.userPassword
        };

        //search info if already existing
        // Search (any name). (key value)
        //querying through the array / searching
        var newUserSearch = userCredentials.find(searchUser =>
            searchUser.FirstName === $scope.firstName &&
            searchUser.MiddleName === $scope.middleName &&
            searchUser.LastName === $scope.lastName
        );

        //need iverify na ung next inputs ay walang katulad sa mga existing values previously stored sa array
        //if may laman / katulad di siya undefined

        //if undefined - push data in array
        if (newUserSearch === undefined) {
            userCredentials.push(registrationData);

            //convert array to JSON string para sa session Storage ng browser
            var sessionString = JSON.stringify(userCredentials);

            //after magsave sa array -> store in temporary browser storage
            sessionStorage.setItem("credentials", sessionString); //key = "credentials" ; yung converted string yung value


            var postData = RegistrationApplicationService.threeFunc(registrationData);
            postData.then(function (ReturnedData) {
                var userFirstName = ReturnedData.data.FirstName;
                var userMiddleName = ReturnedData.data.MiddleName;
                var userLastName = ReturnedData.data.LastName;
                var userAddress = ReturnedData.data.Address;
                var userEmail = ReturnedData.data.Email;
                var userPhoneNumber = ReturnedData.data.PhoneNumber;
                var userPassword = ReturnedData.data.Password;
                var userUsername = ReturnedData.data.Username;
            });

            // Show Swal.fire first, then redirect after it completes
            Swal.fire({
                title: "Login Credentials",
                html: `Username: ${registrationData.Username} <br> Password: ${registrationData.Password}`,
                icon: "success",  // You can add an icon here if needed
                timer: 10000,     // Duration for how long the popup will show
                timerProgressBar: true,
                didOpen: () => {
                    Swal.showLoading();
                }
            }).then((result) => {
                // Redirect after Swal.fire closes (timer or user interaction)
                if (result.dismiss === Swal.DismissReason.timer || result.isConfirmed) {
                    window.location.href = "/Home/LoginPage";
                }
            });

        } else {
            Swal.fire({
                icon: "error",
                title: "Error",
                text: "User already exists!",
            });
            $scope.cancelFunction();
        }
    };


    $scope.loginFunction = function () {
        // Get credentials from sessionStorage
        var storedCredentials = sessionStorage.getItem("credentials");
        var userCredentials = storedCredentials ? JSON.parse(storedCredentials) : [];

        // Retrieve username and password input
        var enteredUsername = $scope.username; // Assuming you have a field for username
        var enteredPassword = $scope.userPassword; // Password input from the user

        // Find the user in the credentials array
        var userExists = userCredentials.find(userSearch =>
            userSearch.Username === enteredUsername && // Use entered username
            userSearch.Password === enteredPassword // Use entered password
        );

        if (userExists) {
            // If user is found, proceed to dashboard or home page
            window.location.href = "/Home/Dashboard";
        } else {
            // If no match, display error message
            Swal.fire({
                icon: "error",
                title: "Error",
                text: "Invalid Username or Password!",
            });
            $scope.dataLoading = false;
        }
    };


    $scope.cancelFunction = function () {
        $scope.firstName = null;
        $scope.middleName = null;
        $scope.lastName = null;
        $scope.address = null;
        $scope.email = null;
        $scope.phoneNumber = null;
        $scope.userPassword = null;
    }

    //3 diff ways to connect to the database
   //$scope.connection1Func = function () {
   //     //connection without parameter

   //     //lahat ng http request ay nasa service.js 
   //     var getData = RegistrationApplicationService.oneFunc();
   //     getData.then(function (ReturnedData) {
   //         var returnedValue = ReturnedData.data;
   //         alert(returnedValue);
   //     });

   // }
   // $scope.connection2Func = function () {
   //     var postData = RegistrationApplicationService.twoFunc($scope.firstName, $scope.lastName); //this is sewuential
   //     postData.then(function (ReturnedData) {
   //         var returnedValue = Number(ReturnedData.data);
   //         if (returnedValue == 1) {
   //             alert("Ban!");
   //         } else {
   //             alert("No ban!")
   //         }

   //     });
   // }

   // $scope.connection3Func = function () {
   //     var registrationData = {
   //         //dito ilalagay key-pair values
   //         FirstName: $scope.firstName,
   //         LastName: $scope.lastName,
   //         Address: $scope.userAddress,
   //         phoneNumber: $scope.userPhone
   //     };

   //     var postData = RegistrationApplicationService.threeFunc(registrationData);
   //     postData.then(function (ReturnedData) {
   //         var sss = ReturnedData.data.FirstName;
   //     })
   // }


    ////This is for showing val of ng-model -- in alert box muna
    // $scope.getAlert = function () {
    //    var alertFname = $scope.firstName;
    //    var alertLname = $scope.lastName;
    //    var alertuAdd = $scope.userAddress;
    //    var alertuPhone = $scope.userPhone;

    //    alert ("First name: " + alertFname + "\nLast name: " + alertLname + "\nUser address: " + alertuAdd + "\nUser phone: " + alertuPhone);
    //    Swal.fire("First name: " + alertFname + "\nLast name: " + alertLname + "\nUser address: " + alertuAdd + "\nUser phone: " + alertuPhone);
    //}



});