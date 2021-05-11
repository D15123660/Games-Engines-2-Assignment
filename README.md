# Games-Engines-2-Assignment
# This project is a set of basic "behaviors" for manipulation. For individual AI characters, basic manipulation behaviors include:
"Seek" and "Flee" behaviors that make the character approach or leave the target;
"Arrival" behavior that slows the character down when he approaches the target;
"Pursuit" behavior that makes hunters chase their prey;
"Evade" behavior that causes prey to escape from predators;
The "Wander" behavior that makes the character wander randomly in the game world;
The "PathFollowing" behavior that makes the character move along a fixed path;
"Obstacle Avoidance" behavior that makes the character avoid obstacles, etc.
# Each of the basic behaviors produces a corresponding control force, so that these control forces are combined in a certain way (in fact, it is equivalent to different combinations of these basic "behaviors"), and you can get more complex "Behavior" to achieve more advanced goals.
For multiple AI characters that form a team or group, the basic group behavior is as follows.
"Separation" behavior that keeps a certain distance from other neighboring characters;
"Alignment" behavior that keeps the same orientation with other neighboring characters;
"Cohesion" behavior close to other adjacent characters;
