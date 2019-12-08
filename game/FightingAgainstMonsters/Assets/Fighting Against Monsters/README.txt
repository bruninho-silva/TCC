Thanx for purchase !!!

---!!! MAX CARDS IN YOUR HAND, IS OF 8!!! (LINE 30 TO "NbrCardsManager.cs")---
---Each game card in your hand has "clickCard.cs" and "DragHandeler.cs".---

---FOR CONFIGURE NbrCardsManager.cs:---

--Open scene with the name "index" to "Asset" folder.
--In Hierarchy, go to "canvas/HandManager" and component "NbrCardsManager.cs".
--Line 48 to 66, configure for distribution of cards to the hands (For edit the number cards maximum in the hand, go line 30).
--Line 71 to 75, configure zoom the card in hand if "cardView" is "true". "cardView" is "true" when mouse over is card.
--Line 69 to 220, configure for position the cards in the hand.
--Line 224 to 234, function of the script "DragHandeler.cs" apply after drag card hand to middle. The function search the card id to the script "clickCard.cs"   and remove -1 total cards in the hand.
--Line 237 to 241, zoom the card active by mouseover and launch function "OnPointerEnter", line 36 in script "clickCard.cs", and Start coroutine line 267 and scale the card. Look "cardView = true" active line 71 to 75.
--Line 244 to 248, mouse Exit zoom the card is off, stopcoroutine line 239, reset scale and "cardView = false".
--Line 251 to 255, active zone to detect drag card game to middle. Line 44 to script "DragHandeler.cs".
--Line 258 to 262, disable zone to detect drag card game to middle after drag and drop off. Line 30 to script "Slot.cs".
--Line 13, configure speed of move the card in your hand when game is start.
--Line 14, configure speed of rotate the card in your hand when distribution.
--Line 12, configure speed of move the card in your hand when distribution.
--Line 24, gameObject money.


---FOR "clickCard.cs"---
--Line 25 to 29, configure image Price, attack and health, grace in line 11, 12 and 13.
--Line 36 to 43  is active when the card mouseover game your hand.
--Line 45 to 51  is disable when the card mouseExite game your hand.
--Line 53 to 55, active function when apply the card game after drag to middle and send "idcarte", line 10, for array in "NbrCardsManager.cs".

---FOR SLOT MIDDLE---
--Open scene with the name "index" to "Asset" folder.
--In Hierarchy, go to "canvas/ColliderPoseMiddle/DetectPose" and component "Slot.cs".
--Line 27, if you have enough money for to place card in middle.
--Line 29, play sound to place card in middle.
--Line 30, launch "CheckSlot2" to "NbrCardsManager.cs" (look the line 12 here).
--Line 31, stop drag to "NbrCardsManager.cs".
--Line 34 to 35, disable the card game to your hand to the clicke.
--Line 37, send to "CheckSlotMiddle.cs" the last position the card game drag to middle.
--Line 43 to 51, send to gameObject slot middle, attack, health and price the card game draged by the mean of the script "CheckSlotMiddle.cs".
--Line 54, add +1 total number card slot middle by "CheckSlotMiddle.cs".
--Line 56 to 59, if you have no money for to place card in middle.
--Line 66, start coroutine line 58 for error.

---FOR CheckSlotMiddle.cs---
--Open scene with the name "index" to "Asset" folder.
--In Hierarchy, go to "canvas/SlotMiddle" and component "CheckSlotMiddle.cs".
--Line 23, play sound to place middle card game (look the line 26 here).
--Line 27 to 560, to place and position card game slot middle.
--Search collision and space between cards of the middle with "BoxRaycasting.cs".

---For Help---
--WebSite : http://www.ricl-chatland.fr/
--Mail : paradox.ultimate@hotmail.fr