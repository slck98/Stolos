﻿using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces;

/*
 * Adrian B on 17/03
 */
public interface IGasCardRepository
{
    List<GasCard> GetAllGasCards();
    GasCard GetGasCard(string cardNum);
}