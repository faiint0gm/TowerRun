# TowerRun

This project is a prototype of a 3D tower jumping game. Any questions/suggestions : p.rudnicki@developerodzera.pl

LevelSetter.cs script is responsible for generation level from steps and walls prefabs.

ColorSetter.cs script is changing color of the material assigned to a prefab using predefined colors.

HeroControl.cs script is main character's controller system. To move character it uses translation based on Vertical and Horizontal axes, and Space button to jump. Jumping method is using raycasting to decide if character is touching any ground or not.

StepController.cs script is managing any behaviours of the steps. It uses OnCollision/OnTrigger methods to turn on and off step colliders, when character is jumping on them from top and from below of the steps.

FloorController.cs script is managing the floor level. It's destroying floor after 3 seconds from the moment character leaves this floor, but if it returns in 3 seconds, the destroying coroutine is being stopped.
