(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('pictureCroppingController', ['$rootScope', '$scope', pictureCroppingController]);

    function pictureCroppingController($rootScope, $scope) {
        var $preview = $('#crop-preview');
        var $previewContainer = $('#crop-preview .crop-preview-container');
        var $previewImage = $('#crop-preview .crop-preview-container img');
        var sizeX = $previewContainer.width();
        var sizeY = $previewContainer.height();
        var jcropApi;
        var boundX;
        var boundY;

        // Register the event on change to the picture input
        document.getElementById('picture-input').onchange = function (event) {
            var target = event.target || window.event.srcElement;
            var files = target.files;

            if (FileReader && files && files.length) {
                var fileReader = new FileReader();
                fileReader.onload = function () {
                    document.getElementById('crop-target').src = fileReader.result;
                    document.getElementById('crop-img').src = fileReader.result;
                    initializeJcrop();
                    jcropApi.setImage(fileReader.result);
                }
                fileReader.readAsDataURL(files[0]);
            }
        };

        // Initialize Jcop
        function initializeJcrop() {
            $('#crop-target').Jcrop({
                onChange: updatePreview,
                onSelect: updatePreview,
                aspectRatio: sizeX / sizeY
            }, setPreview);
        }

        // Set the preview
        function setPreview() {
            jcropApi = this;
            var bounds = jcropApi.getBounds();
            boundX = bounds[0];
            boundY = bounds[1];
            $preview.appendTo(jcropApi.ui.holder);
        }

        // Update the preview
        function updatePreview(crop) {
            if (parseInt(crop.w) > 0) {
                var rx = sizeX / crop.w;
                var ry = sizeY / crop.h;

                $previewImage.css({
                    width: Math.round(rx * boundX) + 'px',
                    height: Math.round(ry * boundY) + 'px',
                    marginLeft: '-' + Math.round(rx * crop.x) + 'px',
                    marginTop: '-' + Math.round(ry * crop.y) + 'px'
                });
            }
        }
    }
})(angular);