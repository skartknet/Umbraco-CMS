﻿function multiItemController($scope, dialogService, entityResource, $log, iconHelper) {


    //init default values
    if (!angular.isObject($scope.model.value)) {
        //if it's legacy boolean value, we cast to new object
        var legacyValue;
        if (typeof ($scope.model.value) === "boolean") {
            legacyValue = $scope.model.value;
        }

        $scope.model.value = {
            multiPicker: legacyValue
        }

    }



    $scope.validate = function () {
        if ($scope.model.value.minNumber > $scope.model.value.maxNumber) {
            $scope.multiItemForm.minNumberField.$setValidity("ing", false);
        }
        else {
            $scope.multiItemForm.minNumberField.$setValidity("ing", true);
        }
    }
}


angular.module('umbraco').controller("Umbraco.PrevalueEditors.MultiItemController", multiItemController);
