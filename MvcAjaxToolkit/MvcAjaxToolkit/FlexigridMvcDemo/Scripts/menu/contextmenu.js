(function ($) {
	var _global;
	var _menus;

	var _overflow = function (x, y) {
		return {
			width: (x && parseInt(x)) ? (x - $(window).width() - $(window).scrollLeft()) : 0,
			height: (y && parseInt(y)) ? (y - $(window).height() - $(window).scrollTop()) : 0
		};
	};

	var _clearActive = function () {
		for (cm in _menus) {
			$(_menus[cm].allContext).removeClass(_global.activeClass);
		}
	};

	var _resetMenu = function () {
		if (_global.activeId) $(_global.activeId).add(_global.activeId + ' ul').hide();
		_global.activeId = null;
		$(document).unbind('.chmenu');
	};

	$.fn.chmenu = function (id, options) {

		if (!_global) _global = {};
		if (!_menus) _menus = {};

		if (options && options.menuClass) _global.menuClass = options.menuClass;
		if (!_global.menuClass) _global.menuClass = 'chmenu';
		if (options && options.activeClass) _global.activeClass = options.activeClass;
		if (!_global.activeClass) _global.activeClass = 'active';

		_menus[id] = $.extend({
			hoverClass: 'hover',
			submenuClass: 'submenu',
			operaEvent: 'contextmenu', //'dblclick',
			fadeIn: 200,
			delay: 300,
			widthOverflowOffset: 0,
			heightOverflowOffset: 0,
			submenuLeftOffset: 0,
			submenuTopOffset: 0,
			autoAddSubmenuArrows: true
		}, options || {});

		// All context bound to this menu.
		_menus[id].allContext = this.selector;

		// Auto add submenu arrows(spans) if set by options.
		if (_menus[id].autoAddSubmenuArrows) $(id).find('li:has(ul)').not(':has(.' + _menus[id].submenuClass + ')').prepend('<span class="' + _menus[id].submenuClass + '"></span>');

		$(id).find('li').unbind('.chmenu').bind('mouseover.chmenu', function (e) {

			var $this = $(this);

			// Clear hide and show timeouts.
			window.clearTimeout(_menus[id].show);
			window.clearTimeout(_menus[id].hide);

			// Clear all hover state.
			$(id).find('*').removeClass(_menus[id].hoverClass);

			// Set hover state on self, direct children, ancestors and ancestor direct children.
			var $parents = $this.parents('li');
			$this.add($this.find('> *')).add($parents).add($parents.find('> *')).addClass(_menus[id].hoverClass);

			// Invoke onHover callback if set, 'this' refers to the hovered list-item.
			// Discontinue default behavior if callback returns false.  
			var continueDefault = true;
			if (_menus[id].onHover) {
				if (_menus[id].onHover.apply(this, [e, _menus[id].context]) == false) continueDefault = false;
			}

			// Continue after timeout(timeout is reset on every mouseover).
			if (!_menus[id].proceed) {
				_menus[id].show = window.setTimeout(function () {
					_menus[id].proceed = true;
					$this.mouseover();
				}, _menus[id].delay);

				e.stopPropagation();
				return false;
			}
			_menus[id].proceed = false;

			// Hide all sibling submenu's and deeper level submenu's.
			$this.parent().find('ul').not($this.find('> ul')).hide();

			if (!continueDefault) {
				e.preventDefault();
				return false;
			}

			// Default behavior.
			// =================================================== //       

			// Position and fade-in submenu's.
			var $submenu = $this.find('> ul');
			if ($submenu.length != 0) {
				var offSet = $this.offset();

				var overflow = _overflow(
					(offSet.left + $this.parent().width() + _menus[id].submenuLeftOffset + $submenu.width() + _menus[id].widthOverflowOffset),
					(offSet.top + _menus[id].submenuTopOffset + $submenu.height() + _menus[id].heightOverflowOffset)
				);
				var parentWidth = $submenu.parent().parent().width();
				var y = offSet.top - $this.parent().offset().top;
				$submenu.css(
					{
						'left': (overflow.width > 0) ? (-parentWidth - _menus[id].submenuLeftOffset + 'px') : (parentWidth + _menus[id].submenuLeftOffset + 'px'),
						'top': (overflow.height > 0) ? (y - overflow.height + _menus[id].submenuTopOffset) + 'px' : y + _menus[id].submenuTopOffset + 'px'
					}
				);

				$submenu.fadeIn(_menus[id].fadeIn);
			}
			e.stopPropagation();
		}).bind('click.chmenu', function (e) {

			// Invoke onSelect callback if set, 'this' refers to the selected listitem.
			// Discontinue default behavior if callback returns false.
			if (_menus[id].onSelect) {
				if (_menus[id].onSelect.apply(this, [e, _menus[id].context]) == false) {
					e.stopPropagation();
					return false;
				}
			}

			// Default behavior.
			//====================================================//

			// Reset menu
			_resetMenu();

			// Clear active state from this context.
			$(_menus[id].context).removeClass(_global.activeClass);

			e.stopPropagation();
		});

		// Event type is a namespaced event so it can be easily unbound later.
		var eventType = _menus[id].event;
		if (!eventType) {
			eventType = $.browser.opera ? _menus[id].operaEvent + '.chmenu' : 'contextmenu.chmenu';
		}
		else {
			eventType += '.chmenu';
		}

		return $(this)[_menus[id].livequery ? 'livequery' : 'bind'](eventType, function (e) {

			// Save context(i.e. the current area to which the menu belongs).
			_menus[id].context = this;
			var $menu = $(id);

			// Check for overflow and correct menu-position accordingly.         
			var overflow = _overflow((e.pageX + $menu.width() + _menus[id].widthOverflowOffset), (e.pageY + $menu.height() + _menus[id].heightOverflowOffset));
			if (overflow.width > 0) e.pageX -= overflow.width;
			if (overflow.height > 0) e.pageY -= overflow.height;
   
			if (_menus[id].onShow) {
				if (_menus[id].onShow.apply($menu, [e, _menus[id].context]) == false) {
					e.stopPropagation();
					return false;
				}
			}

			_resetMenu();

			_global.activeId = id;

			_clearActive();

			$(_menus[id].context).addClass(_global.activeClass);

			$menu.find('li, li > *').removeClass(_menus[id].hoverClass);

			$menu.css({
				'left': e.pageX + 'px',
				'top': e.pageY + 'px'
			}).fadeIn(_menus[id].fadeIn);

			$(document).bind('mouseover.chmenu', function (e) {
				if ($(e.relatedTarget).parents(id).length > 0) {
					
					window.clearTimeout(_menus[id].show);

					var $li = $(e.relatedTarget).parent().find('li');
					$li.add($li.find('> *')).removeClass(_menus[id].hoverClass);
					_menus[id].hide = window.setTimeout(function () {
						$li.find('ul').hide();
					}, _menus[id].delay);
				}
			}).bind('click.chmenu', function (e) {
				if (_global.activeId && _menus[_global.activeId].onHide) {
					if (_menus[_global.activeId].onHide.apply($(_global.activeId), [e, _menus[_global.activeId].context]) == false) {
						return false;
					}
				}
				_clearActive();
				_resetMenu();
			});

			e.stopPropagation();
			return false;
		});
	};

	$.fn.unbindchmenu = function (id) {
		$(this).unbind('.chmenu');
		if (id && _menus[id] instanceof Object) _menus[id] = {};
	};

})(jQuery);