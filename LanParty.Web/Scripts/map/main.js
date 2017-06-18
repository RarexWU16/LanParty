

(function () {
    $(document).ready(function () {
        $("#zoomOut").on("click", app.zoomOut);
        $("#zoomIn").on("click", app.zoomIn);
    });

    var cursors = {
        pointer: function () {
            $('canvas').css('cursor', 'pointer');
        },

        normal: function () {
            $('canvas').css('cursor', 'default');
        },

        move: function () {
            $('canvas').css('cursor', 'move');
        },

        current: function () {
            return $('canvas').css('cursor');
        }
    }

    var app = {
        boxes: [],
        init: function (boxes) {
            app.boxes = boxes;

            app.phaser = new Phaser.Game($("#map-Wrapper").width(), $("#map-Wrapper").height(), Phaser.AUTO, 'map-Wrapper',
            {
                preload: app.preload,
                create: app.create,
                update: app.update
            });
        },
        phaser: undefined,
        currentLevel: {},
        scale: 0.6,
        zoomOut: function () {
            if ((Math.round(app.scale * 10) / 10) > 0.2) {
                app.scale -= 0.2;
                app.fullRedraw();
                if (app.drawnPath != undefined) {
                    app.drawPath(app.drawnPath.key, app.drawnPath.id);
                }
            }

        },
        zoomIn: function () {
            if ((Math.round(app.scale * 10) / 10) < 1.6) {
                app.scale += 0.2;
                app.fullRedraw();
                if (app.drawnPath != undefined) {
                    app.drawPath(app.drawnPath.key, app.drawnPath.id);
                }
            }
        },
        fullRedraw: function () {
            app.phaser.world.removeAll();
            app.create();
        },
        preload: function () {
            app.phaser.load.image("floor", "/content/images/planlosning2.jpg");
        },
        create: function () {
            app.phaser.stage.backgroundColor = "#000000";
            app.phaser.world.setBounds(-1000, -1000, 5000, 5000);
            app.phaser.camera.x = 0;
            app.phaser.camera.y = 0;

            var image = app.phaser.cache.getImage("floor");

            var imageWidth = image.width * app.scale;
            var imageHeight = image.height * app.scale;

            var cameraWidth = app.phaser.camera.width;
            var cameraHeight = app.phaser.camera.height;

            var centerX = (cameraWidth / 2) - (imageWidth / 2);
            var centerY = (cameraHeight / 2) - (imageHeight / 2);

            app.currentLevel.sprite = app.phaser.add.sprite(
                centerX, centerY,
                "floor"
            );

            app.currentLevel.sprite.scale.setTo(app.scale, app.scale);



            $(app.boxes).each(function (i, box) {
                var width = box.Width * app.scale;
                var height = box.Height * app.scale;
                var color = "#fff";

                // drawing rectangle
                var bmd = app.phaser.add.bitmapData(width, height);
                bmd.ctx.beginPath();
                bmd.ctx.rect(0, 0, width, height);
                bmd.ctx.fillStyle = color;
                bmd.ctx.fill();

                var sprite = app.phaser.add.sprite(
                    app.currentLevel.sprite.x + (box.X * app.scale),
                    app.currentLevel.sprite.y + (box.Y * app.scale),
                    bmd
                );

                sprite.inputEnabled = true;
                sprite.anchor.setTo(0.5, 0.5);
                sprite.angle = box.rotation;

                sprite.events.onInputOver.add(() => {
                    cursors.pointer();
                }, this);

                sprite.events.onInputOut.add(() => {
                    cursors.normal();
                }, this);

                sprite.events.onInputDown.add(() => {
                    window.location.href = "/Seats/Book?seatId=" + box.Id;
                }, this);
            })
        },
        update: function () {
            if (app.phaser.input.activePointer.isDown) {
                if (app.phaser.origDragPoint != null) {
                    // move the camera by the amount the mouse has moved since last update
                    app.phaser.camera.x += app.phaser.origDragPoint.x - app.phaser.input.activePointer.position.x;
                    app.phaser.camera.y += app.phaser.origDragPoint.y - app.phaser.input.activePointer.position.y;
                }
                app.phaser.origDragPoint = {
                    x: app.phaser.input.activePointer.position.x,
                    y: app.phaser.input.activePointer.position.y
                }
            }
            else {
                app.phaser.origDragPoint = null;
            }
        },
    }

    window.map = app.init;
})();

// load data to localStorage




// Main app
