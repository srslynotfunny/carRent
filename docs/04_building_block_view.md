Bausteinsicht {#section-building-block-view}
=============

**Context**

![context](/images/context.png)

**Containers**

![containers](/images/containers.png)

**Components**

![components](/images/component.png)

Im folgendem Diagramm ist aufgezeigt, wie der Zugriff auf die Car Klasse gewährleistet ist.

![carClass Access](/images/systemBausteine.png)

Speziell hier ist der Baustein "Automapper". Mit diesem Paket wird die Car Klasse zur CarReadDto Klasse gemappt.
Die CarReadDto (Data Transfer Object) wird benutzt, um dem Benutzer nur gewollte Informationen mitzuteilen. In dem Fall der Car Klasse
werden alle Infos mitgegeben, da sie nur für den Sachbearbeiter gedacht ist und daher keine Infos vorbehalten werden müssen.

Jede Anfrage wird zuerste gemappt, damit das Datenhandling gut funktioniert. Bei falscher Eingabe resultiert ein Bad Request.
