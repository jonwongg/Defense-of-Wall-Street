# Defense of Wall Street: We are the 1%
Written by Jonathan Wong, Drew Mulock, Bret Schofield

## Introduction

JDB Inc. is proud to present its first release: Defense of Wall Street: We are the 1% (DoWS).
DoWS is a first person shooter tower defense game that takes the current hot topic in news,
Occupy Wall Street, and spins it into a form of entertainment. The player is put into the shoes of
a greedy CEO, called Nameless, as he defends Wall Street from ‘the 99%’ of the population as
they attempt to protest socioeconomic inequality.

This document aims to provide the reader with an overview of the design process and
development lifecycle of DoWS, as well as well as the many obstacles that were encountered and
how they were overcome.

## Design

### Gameplay Highlights

Several gameplay highlights of DoWS include: transformable blocks on which the player can
build towers, three unique towers, a grapple-hook mechanic, a first person shooter mechanic, and
many waves of enemies. The transformable blocks allow the player to aim at and transform the
blocks into towers for currency. An interesting feature, demonstrated in figure 1.0, is the
highlighting of these transformable blocks when aimed upon by the crosshair.


```
Figure 1.0 – In the upper left-hand corner of the screen, the player’s currency is displayed, and upon clicking on a transformable building block, a
menu appears to select a tower for purchase.
```
The three towers include: the IDM, the Repressor, and the Tax Return. The IDM fires a single
credit card, dealing damage equivalent to a single credit shuriken thrown by Nameless. The
Repressor periodically pushes any passing protesters backwards, and the Tax Return slows and
deals damage to any protesters who walk over it. A strategic player will combine these for
maximum efficiency and protester control.

Figure 1.1 (^) Return, while the Repressor ahead allows its adjacent IDM to have two shots in addition to it displacing the protesters.– A player has set two Repressors to push protesters in succession into a Tax Return, maximizing slow and damage from the Tax


### Asset Creation

Assets were created in Blender. Learning Blender proved to be an obstacle in itself; learning how
to manipulate simple cubes into more sophisticated models took a great deal of experimentation
as well as online research. One example of research paying off was the discovery of the inset
extrude tool. This tool combined the face scale and extrude into one tool, cutting down on time
and extra, unnecessary manipulations. After modeling, the next biggest obstacle was the
unwrapping of the models to obtain a UV map for texture creation. While it was not difficult to
get a UV map, unraveling the geometry so that it is easy to deal with on a UV map is still a
struggle and requires much trial and error.

The animation of the assets was also handled in Blender. These took a great amount of time, and
the enlightened the group on how difficult it is to attempt to mimic how body parts move; this
lead to exercises of walking, jogging, and kneeling in place in front of a mirror.

### Technical Challenges

Many technical challenges were encountered in scripting, but were overcome. Several of these,
however, were resolved through ‘cheap’ fixes. Such fixes include the transformable building
blocks to towers causing undesired rotations of the created towers. A simple, time-saving work-
around was to have the possible four orientations of the Repressor and the IDM (eight in total) in
the scene, outside of the playable area. Because of the structure of the tower scripting, these
could then be dragged into the Inspector in Unity, where the possible four locations of the
building blocks (to the left or right of a vertical segment of the street, or above or below a
horizontal segment of the street) were located. This was also the case for the protestors.


While Quaternion manipulations could have certainly solved the tower orientation problem, it
was discovered that it was not possible for JDB to specify the protestor movement waypoints in
the prefabs of the protestors. The current solution, where the eight possible protestors with
defined waypoints are also placed outside of the playable area of the scene, was discovered
through the Unity Egg catcher game example. In this, it was discovered that a prefab of an egg
was placed on the scene, and was then used to instantiate all of the other eggs.

### Unique Game Features

A grapple hook mechanic has been implemented for Nameless. By highlighting a grapple
location (figure 1.2), the player is able to press R (figure 1.3), and reach the destination (figure
1.4).

Figure 1.2 – The grapple location has been highlighted Figure 1.3 – The player is latched on and moving toward the location

Figure 1.4 – The player has reached the location


Unfortunately, the created asset for the grapple hook was not implemented, and so there is no
animation to accompany the grapple mechanic.

### Management Issues

Management turned out to be a fairly big problem. Due to the fact that no real manager was
appointed or decided upon, the allocation of members’ time was not always efficient. This led to
JDB realizing the importance of someone assuming a lead role and coordinating the others.

### Future Work

Future work includes more in-depth levels, an upgrade system that would include statistical and
aesthetic changes, a bigger enemy variation, bosses, more weapons for Nameless, more uses, or
incentives for use, of the grapple hook mechanic, and overall polish (better models, textures,
animations, cleaner code, original sound and music, etc).

There are assets which have been created but not implemented. These are explained in the next
section, but include a grapple hook (figure 1.5) and a scanner gun, both of which were intended
for Nameless.

```
Figure 1.5 – The grapple hook gun that was unfortunately not implemented due to difficulties implementing rope.
```

## Lessons Learned............................................................................................................................................

One lesson learned by JDB Inc. is the importance of planning. It would have been helpful to set
strict deadlines for certain tasks to be completed, and to appropriately plan around the deadlines
of the members’ other courses so that the project could be brought to a satisfactory level of
completion.

Another lesson learned would be prioritization of tasks. For example, spending time attempting
to create an object-oriented structure of the program code, while lacking the level of experience
or the amount of time required, and then fully planning and creating such a structure that was
then scrapped, ended up being a setback. Another example is the creation of a cinematic, and the
creation of assets such as signs and garbage cans. While these are integral to the team’s vision of
their complete and polished product, they are unnecessary, and it was not known to the team that
movies cannot be played on the free version of Unity until the cinematic was actually created.

## Conclusion

Despite the state of the finished product and the obstacles that were encountered through the
creation of Defense of Wall Street: We are the 1%, JDB Inc. is proud to present its first release.
Many important lessons have been learned, from prioritization of project tasks to project
planning. While achieving an efficient code structure allows for easy future work, sometimes it is
necessary to simply do what works to meet deadlines, regardless of how sloppy it is and so long
as it has no real impact on the game.

With the experience gained from the creation of Defense of Wall Street: We are the 1%, JDB Inc.
is ready to begin improvement on DoWS and planning for future projects. We hope everyone
enjoys playing DoWS as much as we had creating it!
