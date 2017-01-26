angular.module('umbraco').controller('Skrift.ContactPersons.Controller', function ($scope) {
    
    if (!$scope.control.value) {
        $scope.control.value = {
            title: '',
            items: []
        };
    }

    $scope.config = {
        title: $scope.control.editor.config.title,
        hest: '1234',
        limit: $scope.control.editor.config.limit
    };

    $scope.addItem = function() {
        $scope.control.value.items.push({
            name: '',
            title: '',
            email: ''
        });
    };

    $scope.removeItem = function (index) {
        var temp = [];
        for (var i = 0; i < $scope.control.value.items.length; i++) {
            if (index != i) temp.push($scope.control.value.items[i]);
        }
        $scope.control.value.items = temp;
    };


    $scope.sortableOptions = {
        axis: 'y',
        cursor: 'move',
        handle: '.handle',
        tolerance: 'pointer',
        placeholder: 'contacts-sortable-placeholder',
        containment: 'parent'
    };

});