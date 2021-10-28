*Last Edit: 23/07/2021
*Edited by: Marc Andrews

Grass Shader is a URP Shader Graph Shader

============OVERVIEW=============

The Grass shader is an opaque shader that uses alpha clipping with a mask to make a grass effect on planes.

==========EXTRA_DETAILS==========

It creates a wind effect by offsetting it position by (wind Movement * time) which then has a noise gradient applied.

We then lerp between this and the world position by the Y position on the UV map to keep the grass more rooted near the bottom.

============SETTINGS==============

=Alpha Mask=:
determines the shape of the grass can be changed with any other shape as long as it maintains the horizontal division and a black and white colour scheme

=Wind Movement=: 
effects the UV movement direction

=Wind Density=:
effects the distortion effect of the wind

=Wind Strength=:
effects the force of the movement

=Colour Height=:
effects the blend position of the colour gradient

=Alpha Clipping=:
culls around the alpha mask to form the desired shape

=Power=:
effects how bright the colour is and allows you to push the colour past the colour picker

=Normal Power=:
changes how visible the normal is for the grass
-(note) this can be used to give some slight random colour to the grass

==========OPTIMISATION===========

Recommendations:

-Turn cast shadows off on the meshrenderer of any grass in the scene

- Use GPU Instancing on Grass Materials