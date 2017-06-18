

(function () {
    var $image = $("#BoxEditor .FloorImage"),
        $box = $("#boxEditorImageWrapper .box"),
        $saveButton = $("#BoxEditor .SaveBox")

    var scale = {
        toNatural: NaN,
        toCurrent: NaN,
    }

    function boxEditor(options) {
        // checking if required options for normal operation exits
        if (options.saveCallback == undefined) {
            console.log("The box editor can not init without a saveBoxCallback");
            return;
        }
        if (options.imageUrl == undefined) {
            console.log("The box editor can not init without a image Url");
            return;
        }

        if (options.color != undefined) {
            $box.css("background-color", options.color);
        }
        else {
            $box.css("background-color", "#000");
        }


        // setup jquery ui draggable
        $box.draggable({
            stop: updateForm
        });

        $("#boxEditor-rotation").roundSlider({
            min: 0,
            max: 360,
            circleShape: "full",
            step: 1,
            value: 0,
            width: 10,
            radius: 70,
            drag: updateLiveBox,
            change: updateLiveBox,
            handleSize: "24,12",
            handleShape: "square",
            sliderType: "min-range",
        });

        //
        // Events
        //

        // onSubmit
        $saveButton.on("click", function (e) {
            e.preventDefault();

            var values = getValues();
            values.x = parseFloat(values.x) + (parseFloat(values.width) / 2);
            values.y = parseFloat(values.y) + (parseFloat(values.height) / 2);

            options.saveCallback(values);
        });

        $image.attr("src", "/content/images/planlosning2.jpg");

        $image.on("load", function () {
            var naturalWidth = parseFloat(document.querySelector("#BoxEditor .FloorImage").naturalWidth),
            naturalHeight = parseFloat(document.querySelector("#BoxEditor .FloorImage").naturalHeight);

            // Gets the current width and height of the image
            var currentWidth = parseFloat($image.width()),
                currentHeight = parseFloat($image.height());

            scale.toNatural = naturalWidth / currentWidth,
            scale.toCurrent = currentWidth / naturalWidth;

            clearForm();

            // load from json
            if (options.json != undefined) {
                loadFromJson(options.json);
            }

            updateLiveBox();
        });


        $("#BoxEditor input[type=number]").on("change", function () {
            updateLiveBox();
        });
    }

    function displayAll() {
        $.ajax({
            url: "/Seats/GetBoxes",
            method: "GET",
            success: (boxes) => {
                boxes.map((box) => {
                    var x = box.X * scale.toCurrent
                    var y = box.Y * scale.toCurrent
                    var width = box.Width * scale.toCurrent
                    var height = box.Height * scale.toCurrent
                    $("#boxEditorImageWrapper").append(
                        [
                            "<div style='position:absolute;",
                            "background-color: #000000;",
                            "top:" + y + "px;",
                            "left:" + x + "px;",
                            "width:" + width + "px;",
                            "height:" + height + "px;",
                            "transform: translate(-50%, -50%) rotate(" + box.Rotation + "deg);'",
                            "></div>"
                        ].join("")
                    );
                })
            }
        })

    }

    function loadFromJson(jsonString) {
        var box = {};
        console.log(jsonString);
        if (jsonString != "" || jsonString != null) {
            var box = JSON.parse(jsonString);

            box.x = parseFloat(box.x) - (parseFloat(box.width) / 2);
            box.y = parseFloat(box.y) - (parseFloat(box.height) / 2);
        }

        setValues(box);
    }

    function updateForm(event, ui) {
        var x = parseFloat(ui.position.left) * scale.toNatural;
        var y = parseFloat(ui.position.top) * scale.toNatural;

        setValues({
            x: parseInt(x),
            y: parseInt(y)
        });
    }

    function updateLiveBox() {
        var box = getValues();

        var x = parseFloat(box.x) * scale.toCurrent,
            y = parseFloat(box.y) * scale.toCurrent,
            width = parseFloat(box.width) * scale.toCurrent,
            height = parseFloat(box.height) * scale.toCurrent;

        $box.css("width", width + "px")
            .css("height", height + "px")
            .css("left", x + "px")
            .css("top", y + "px")
            .css("transform", "rotate(" + box.rotation + "deg)");
    }

    function setValues(box) {
        if (box.x != undefined) {
            $("#boxEditor-x").val(box.x);
        }

        if (box.y != undefined) {
            $("#boxEditor-y").val(box.y);
        }

        if (box.width != undefined) {
            $("#boxEditor-width").val(box.width);
        }

        if (box.height != undefined) {
            $("#boxEditor-height").val(box.height);
        }

        if (box.rotation != undefined) {
            $("#boxEditor-rotation").roundSlider("setValue", box.rotation);
        }

        updateLiveBox();
    }

    function getValues() {
        return {
            x: $("#boxEditor-x").val(),
            y: $("#boxEditor-y").val(),
            width: $("#boxEditor-width").val(),
            height: $("#boxEditor-height").val(),
            rotation: $("#boxEditor-rotation").roundSlider("getValue")
        }
    }

    function clearForm() {
        $("#boxEditor-x").val(0);
        $("#boxEditor-y").val(0);
        $("#boxEditor-width").val(100);
        $("#boxEditor-height").val(100);
        $("#boxEditor-rotation").val(0);
        updateLiveBox();
    }

    window.boxEditor = boxEditor;
})();