app.service("RegistrationApplicationService", function ($http) {
    this.threeFunc = function (registrationData) {
        var response = $http({
            method: "post",
            url: "/Home/ThreeFunction", //kung anong function tatawagin sa controller
            data: registrationData
        });
        return response;
    }
    //this = service
    //scope = controller

});
